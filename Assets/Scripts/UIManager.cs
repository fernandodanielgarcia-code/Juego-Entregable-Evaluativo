using Unity.Netcode;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void QuitGame()
    {
        NetworkManager.Singleton?.Shutdown();
        Application.Quit();
    }
}
