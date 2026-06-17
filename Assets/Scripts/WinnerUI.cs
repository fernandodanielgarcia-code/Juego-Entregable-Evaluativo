using TMPro;
using UnityEngine;

public class WinnerUI : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    private bool alreadyShown = false;

    void Update()
    {
        if (alreadyShown) return;

        if (GameManager.instance == null) return;

        if (!GameManager.instance.gameEnded.Value) return;

        alreadyShown = true;

        ulong winner = GameManager.instance.winnerClientId.Value;

        winnerText.gameObject.SetActive(true);
        winnerText.text = "PARTIDA TERMINADA\n\n" + "Ganador: Jugador " + (winner + 1);
    }
}
