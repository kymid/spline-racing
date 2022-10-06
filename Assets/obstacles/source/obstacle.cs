using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    [SerializeField] PLayerMovement pLayerMovement;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        pLayerMovement.players.Remove(other.gameObject);
        Destroy(other.gameObject);
    }
}
