using UnityEngine;
using UnityEngine.SceneManagement;

public class PUCLOGO : MonoBehaviour
{
    private void Start()
    {
        Invoke("StartGame", 2);
    }
    private void StartGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
