using System;
using DG.Tweening;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private RectTransform background;

    private void Start()
    {
        if (GameManager.Instance.IsTutorialComplete) return;
        
        Enable();
    }

    private void Enable()
    {
        background.DOScale(Vector3.one, 0.25f);
    }

    public void Disable()
    {
        background.DOScale(Vector3.zero, 0.25f);

        GameManager.Instance.IsTutorialComplete = true;
    }
}
