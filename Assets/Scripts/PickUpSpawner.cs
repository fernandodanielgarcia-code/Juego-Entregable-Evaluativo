using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class PickUpSpawner : NetworkBehaviour
{
    public static PickUpSpawner Instance;
    public GameObject pickupPreFab;
    public int maxPickups = 5;
    public float respawnTime = 3f;
    public float mapSize = 10f;

    private int currentPickups = 0;

    private void Awake()
    {
        Instance = this;
    }

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;

        for (int i = 0; i < maxPickups; i++)
        {
            SpawnPickup();
        }
    }

    public void SpawnPickup()
    {
        if (currentPickups >= maxPickups) return;

        GameObject pickup = Instantiate(pickupPreFab, GetRandomPosition(), Quaternion.identity);

        pickup.GetComponent<NetworkObject>().Spawn();

        currentPickups++;
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-mapSize, mapSize), 1f, Random.Range(-mapSize, mapSize));
    }

    public void OnPickupCollected()
    {
        currentPickups--;

        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnPickup();
    }
}
