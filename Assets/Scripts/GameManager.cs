using UnityEngine;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    public static GameManager instance;

    public NetworkVariable<float> timeRemaining = new NetworkVariable<float>(120f);

    public NetworkVariable<bool> gameEnded = new NetworkVariable<bool>(false);

    public NetworkVariable<ulong> winnerClientId = new NetworkVariable<ulong>(999999);

    private void Awake()
    {
        instance = this;
    }
    
    private void Update()
    {
        if (!IsServer) return;

        if (gameEnded.Value) return;

        timeRemaining.Value -= Time.deltaTime;

        

        if (timeRemaining.Value <= 0)
        {
            timeRemaining.Value = 0;
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnded.Value = true;

        int highestScore = -1;
        ulong winnerId = 999999;

        foreach(var client in NetworkManager.Singleton.ConnectedClientsList)
        {
            PlayerCollector collector = client.PlayerObject.GetComponent<PlayerCollector>();

            if (collector == null) continue;

            if(collector.score.Value > highestScore)
            {
                highestScore = collector.score.Value;
                winnerId = client.ClientId;
            }
        }

        winnerClientId.Value = winnerId;

        Debug.Log("Partida terminada. Ganador: " + winnerClientId.Value + " Score: " + highestScore);
    }
}
