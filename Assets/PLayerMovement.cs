using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using DG.Tweening;

public class PLayerMovement : MonoBehaviour
{
    public List<GameObject> players;

    public void SetPosition(SplineComputer comp)
    {
        double poseonline = 1d/(1d + players.Count);
        for (int i = 0; i < players.Count; i++)
        {
            double percent = poseonline + poseonline * i;
            Debug.Log(comp.EvaluatePosition(percent, SplineComputer.EvaluateMode.Cached));
            players[i].transform.DOMove(comp.EvaluatePosition(percent,SplineComputer.EvaluateMode.Cached), 1f).SetSpeedBased();
        }
    }
}