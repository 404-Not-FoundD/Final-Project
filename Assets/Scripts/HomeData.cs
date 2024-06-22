using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeData : MonoBehaviour
{
    public void BackHome() // Home button for every scenes
    {   
        SceneManager.LoadScene("MainScene");
    }
}