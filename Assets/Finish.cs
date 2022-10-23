using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Finish : MonoBehaviour
{
    [SerializeField] float plusx, plusz, currentX, currentZ;
    [SerializeField] PLayerMovement pMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || GameStatement.Instance.currentState != GameStatement.State.Play) return;

        GameStatement.Instance.FromPLayToFinish();

        for (int i = 0; i < pMovement.players.Count; i++)
        {
            pMovement.players[i].transform.DOMove(new Vector3(transform.position.x + currentX,
                pMovement.players[i].transform.position.y, transform.position.z + currentZ), 1f);

            pMovement.players[i].GetComponent<Animator>().SetBool("isWin", true);

            currentX += plusx;
            if(currentX >= 0.4f)
            {
                currentX = -.4f;
                currentZ -= plusz;
            }
        }
    }
}
