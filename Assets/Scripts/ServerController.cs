using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ServerController : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            NetworkManager.Singleton.StartHost();

            NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            NetworkManager.Singleton.StartClient();
        }
    }
}
