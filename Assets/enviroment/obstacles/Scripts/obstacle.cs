using UnityEngine;

public class obstacle : MonoBehaviour
{
    [SerializeField] PlayerMovement pMovement;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        pMovement.players.Remove(other.gameObject);
        Destroy(other.gameObject);
    }
}
