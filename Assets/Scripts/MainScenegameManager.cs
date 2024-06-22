using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneGameManager : MonoBehaviour
{
    public int hiScore = 0;
    public Text hiScoreText;
    
    public void Start()
    {
        if (StaticData.hiScoreToKeep != null) {
            hiScore = int.Parse(StaticData.hiScoreToKeep);
        }
        
        hiScoreText.text = hiScore.ToString("D5");
    }

    public void StartGame() // Game start button
    {
        SceneManager.LoadScene("Login");
    }

    public void EndGame()
    {
        Application.Quit();
    }
}