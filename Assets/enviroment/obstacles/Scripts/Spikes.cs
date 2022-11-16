using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour
{
    [SerializeField] Ease ease;
    void Start()
    {
        transform.DOLocalMoveZ(0.1f, 1.5f).SetEase(ease).SetLoops(-1,LoopType.Yoyo);
    }
}
