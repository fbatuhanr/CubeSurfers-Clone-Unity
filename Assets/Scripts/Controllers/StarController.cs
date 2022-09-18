using DG.Tweening;
using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField] private Transform model;
    
    private void Start()
    {
        model.DOLocalMoveY(0.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        model.DOLocalRotate(Vector3.forward * 360, 1f).SetLoops(-1).SetRelative(true);
    }
}
