using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPlayer : MonoBehaviour
{
    [SerializeField] PLayerMovement pMovement;

    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Destroy(transform.GetComponent<CollectPlayer>());
        if(!pMovement.players.Contains(gameObject))
        {
            transform.GetComponent<Animator>().SetBool("isRun", true);
            pMovement.players.Add(gameObject);

            foreach(GameObject p in pMovement.players)
            {
                p.GetComponent<Animator>().Play("Run",-1,.2f);
            }
        }

        transform.parent = pMovement.transform;
    }
}
