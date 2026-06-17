using UnityEngine;
using Unity.Netcode;

public class PlayerCollector : NetworkBehaviour
{
    public bool isCarrying = false;

    public NetworkVariable<int> score = new NetworkVariable<int>(0);
}
