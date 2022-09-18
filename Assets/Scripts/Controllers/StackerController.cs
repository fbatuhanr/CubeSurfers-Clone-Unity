using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class StackerController : MonoBehaviour
{
    [Tag] [SerializeField] private string stackTag, obstacleTag, finishAreaTag, starTag;
    [SerializeField] private Transform stacksParent;
    [SerializeField] private float stackHeight;
    private Vector3 StackHeight => Vector3.up * stackHeight;
    public int StacksParentChildCount => stacksParent.childCount;

    [Header("Stack Collect and Drop Animations:")]
    [SerializeField] private float collectAnimDuration;
    [SerializeField] private float dropAnimDuration;
    [SerializeField] private Ease collectAnimType;
    [SerializeField] private Ease dropAnimType;

    private int beginningStackCount;
    private void Start()
    {
        beginningStackCount = StacksParentChildCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(stackTag) && other.transform.parent != stacksParent)
        {
            var collectedStack = other.transform;
            
            collectedStack.SetParent(stacksParent);
            
            var stackedCount = StacksParentChildCount-beginningStackCount;
            var nextStackPosition = StackHeight * stackedCount;
            
            collectedStack
                .DOLocalMove(nextStackPosition, collectAnimDuration)
                .SetEase(collectAnimType)
                .OnComplete(() => {
                    collectedStack.GetComponent<StackController>().EnableLabel();
                });

            CameraManager.Instance.IncreaseCameraHeight(StacksParentChildCount, StackHeight);
        }
        else if (other.CompareTag(finishAreaTag))
        {
            GameManager.Instance.IsEnteredToFinishLine = true;
            CameraManager.Instance.FinishAreaCamPriority();
        }
        else if (other.TryGetComponent(out RevenueMultiplier revenueMultiplier))
        {
            GameManager.Instance.reachedLastMultiplier = revenueMultiplier.multiplyAmount;
        }
        else if (other.CompareTag(starTag))
        {
            GameManager.Instance.collectedStarCount++;
            
            other.transform.DOMove(new Vector3(4, 15, other.transform.position.z+10), .5f)
                .SetEase(Ease.InSine)
                .OnComplete(() =>
                {
                    Destroy(other.gameObject);
                    CanvasUIController.Instance.collectedStarsUI.UpdateStarCount();
                });
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(obstacleTag) && !other.TryGetComponent(out RevenueMultiplier _))
        {
            var stackCounter = 0;
            foreach (Transform stack in stacksParent)
            {
                var currStackPosition = StackHeight * stackCounter++;
                
                stack
                    .DOLocalMove(currStackPosition, dropAnimDuration)
                    .SetEase(dropAnimType);
            }
            
            CameraManager.Instance.DecreaseCameraHeight(StacksParentChildCount, StackHeight);
        }
    }
}
