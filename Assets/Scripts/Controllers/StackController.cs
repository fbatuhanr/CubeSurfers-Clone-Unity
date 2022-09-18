using DG.Tweening;
using UnityEngine;

public class StackController : MonoBehaviour
{

    [SerializeField] private RectTransform labelBackground;

    public void EnableLabel()
    {
        labelBackground
            .DOScale(Vector3.one, 0.25f).SetEase(Ease.OutElastic)
            .OnComplete(DisableLabel);
    }

    public void DisableLabel()
    {
        labelBackground.DOScale(Vector3.zero, 0.5f).SetDelay(1f);
    }
}
