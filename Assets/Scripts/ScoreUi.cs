using UnityEngine;
using TMPro;
using Unity.Netcode;
using System.Text;

public class ScoreUi : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        if (NetworkManager.Singleton == null) return;

        StringBuilder sb = new StringBuilder();

        int playerNumber = 1;

        foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
        {
            PlayerCollector collector = client.PlayerObject.GetComponent<PlayerCollector>();

            if (collector != null)
            {
                sb.AppendLine($"Jugador {playerNumber}: {collector.score.Value}");

                playerNumber++;
            }
        }

        scoreText.text = sb.ToString();
    }
}
