using NaughtyAttributes;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [Tag] [SerializeField] private string stackTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(stackTag))
        {
            var stack = other.transform;
            var stackParent = stack.parent;
            
            stack.SetParent(null);
            Destroy(stack.GetComponent<BoxCollider>());
            
            if (stackParent == null) return;
            CheckGameIsOver(stackParent.childCount);
        }
    }

    private void CheckGameIsOver(int currStackCount)
    {
        if (currStackCount > 0 && GameManager.Instance.reachedLastMultiplier < 11) return;
        
        if (GameManager.Instance.IsEnteredToFinishLine)
        {
            GameManager.Instance.IsGameComplete = true;
            
                CanvasUIController.Instance.completedResultsUI.Enable();
        }
        else
        {
            GameManager.Instance.IsGameover = true;
            
                CanvasUIController.Instance.gameoverResultsUI.Enable();
        }
    }
}
