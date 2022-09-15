using System;
using DG.Tweening;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stacker : MonoBehaviour
{
    [Tag] [SerializeField] private string stackTag, obstacleTag;
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
            
            var stacksCount = StacksParentChildCount-beginningStackCount;
            
            var currStackPosition = StackHeight * stacksCount;

            /*var collectedStackRotation = stacksParent.GetChild(StacksParentChildCount - 2).localRotation.y > 0 ? -10f : 10f;
            collectedStack.DOLocalRotate(Vector3.up * collectedStackRotation, .5f);*/
            collectedStack
                .DOLocalMove(currStackPosition, collectAnimDuration)
                .SetEase(collectAnimType);
            
            CameraManager.Instance.IncreaseCameraHeight(StacksParentChildCount, StackHeight);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(obstacleTag))
        {
            var stackCounter = 0;
            foreach (Transform stack in stacksParent)
            {
                var currStackPosition = StackHeight * stackCounter++;
                Debug.Log("curr stack pos: " + currStackPosition);
               
                //stack.localPosition = currStackPosition;
                stack
                    .DOLocalMove(currStackPosition, dropAnimDuration)
                    .SetEase(dropAnimType);
            }
            
            CameraManager.Instance.DecreaseCameraHeight(StacksParentChildCount, StackHeight);
        }
    }
}
