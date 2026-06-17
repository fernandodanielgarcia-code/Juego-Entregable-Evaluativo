using UnityEngine;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    public static GameManager instance;

    public NetworkVariable<float> timeRemaining = new NetworkVariable<float>(120f);

    private void Awake()
    {
        instance = this;
    }

    //private float debugTimer = 0f;
    private void Update()
    {
        if (!IsServer) return;

        if (timeRemaining.Value <= 0 ) return;

        timeRemaining.Value -= Time.deltaTime;

        /*debugTimer += Time.deltaTime;

        if (debugTimer >= 5f)
        {
            debugTimer = 0f;
            Debug.Log(timeRemaining.Value);
        }*/

        if (timeRemaining.Value < 0)
        {
            timeRemaining.Value = 0;
        }
    }
}
