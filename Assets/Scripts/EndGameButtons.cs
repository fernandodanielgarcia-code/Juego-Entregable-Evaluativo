using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
public class EndGameButtons : MonoBehaviour
{
    public void ReturnToMenu()
    {
        NetworkManager.Singleton.Shutdown();

        SceneManager.LoadScene("MainMenu");
    }
}
