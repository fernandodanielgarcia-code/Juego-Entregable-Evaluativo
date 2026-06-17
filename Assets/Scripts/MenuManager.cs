using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
   public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }
}
