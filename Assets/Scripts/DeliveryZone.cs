using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        PlayerCollector collector = other.GetComponent<PlayerCollector>();

        if (collector == null) return;

        if (!collector.isCarrying) return;
            
        collector.isCarrying = false;
        collector.score++;

        Debug.Log("Punto! Score: " + collector.score);
        
    }
}
