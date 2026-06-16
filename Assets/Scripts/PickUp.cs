using UnityEngine;
using Unity.Netcode;
public class PickUp : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!IsServer) return;

        if (other.CompareTag("Player"))
        {
            PlayerCollector collector = other.GetComponent<PlayerCollector>();

            if (collector == null) return;

            if(collector.isCarrying) return;

            collector.isCarrying = true;
            
            Debug.Log("Objeto recogido");

            PickUpSpawner.Instance.OnPickupCollected();

            GetComponent<NetworkObject>().Despawn();
        }
    }
}
