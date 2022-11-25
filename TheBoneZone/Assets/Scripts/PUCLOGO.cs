using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PUCLOGO : MonoBehaviour
{
    public Image img;
    private void Start()
    {
        Invoke("StartGame", 2);
    }
    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
