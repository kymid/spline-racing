using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hammer : MonoBehaviour
{
    void Start()
    {
        transform.DOLocalRotate(Vector3.zero, 1).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }

}
