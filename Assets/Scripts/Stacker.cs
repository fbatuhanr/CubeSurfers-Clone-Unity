using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class Stacker : MonoBehaviour
{
    [Tag] [SerializeField] private string stackTag, obstacleTag;
    [SerializeField] private Transform stacksParent;
    [SerializeField] private float stackOffset;

    [Header("Stack Collect and Drop Animations:")]
    [SerializeField] private float collectAnimDuration;
    [SerializeField] private float dropAnimDuration;
    [SerializeField] private Ease collectAnimType;
    [SerializeField] private Ease dropAnimType;

    private int beginningStackCount;
    private void Start()
    {
        beginningStackCount = stacksParent.childCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(stackTag) && other.transform.parent != stacksParent)
        {
            var collectedStack = other.transform;
            
            collectedStack.SetParent(stacksParent);
            
            var stacksCount = stacksParent.childCount-beginningStackCount;
            
            var currStackPosition = Vector3.up * stacksCount;
            
            // collectedStack.localPosition = currStackPosition
            collectedStack
                .DOLocalMove(currStackPosition, collectAnimDuration)
                .SetEase(collectAnimType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(obstacleTag))
        {
            var stackCounter = 0;
            foreach (Transform stack in stacksParent)
            {
                var currStackPosition = Vector3.up * stackCounter++;
               
                //stack.localPosition = currStackPosition;
                stack
                    .DOLocalMove(currStackPosition, dropAnimDuration)
                    .SetEase(dropAnimType);

            }
        }
    }
}
