using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Road : MonoBehaviour
{
    public float speed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }
}
