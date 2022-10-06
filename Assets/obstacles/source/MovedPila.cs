using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovedPila : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMoveX(-5, 5).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }

}
