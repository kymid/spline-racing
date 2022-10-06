using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleBita : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(-90,
            0, 360), 1).SetLoops(-1,LoopType.Incremental).SetEase(Ease.Linear);
    }

}
