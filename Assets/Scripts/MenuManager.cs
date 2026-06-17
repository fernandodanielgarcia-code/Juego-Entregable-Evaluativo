using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Netcode.Transports.UTP;
public class MenuManager : MonoBehaviour
{
    public TMP_InputField ipInput;
    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void StartClient()
    {
        string ip = ipInput.text.Trim();

        if (string.IsNullOrEmpty(ip))
        {
            ip = "127.0.0.1";
        }

        UnityTransport transport = NetworkManager.Singleton.GetComponent<UnityTransport>();

        transport.ConnectionData.Address = ip;

        NetworkManager.Singleton.StartClient();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
