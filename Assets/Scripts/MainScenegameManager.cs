using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneGameManager : MonoBehaviour
{
    public int hiScore = 0;
    public Text hiScoreText;
    
    public void Start()
    {
        /* *** WHAT HISCORE DO WE NEED TO KEEP? ***
        // hiScore = int.Parse(StaticData.hiScoreToKeep);
        */
        
        hiScoreText.text = hiScore.ToString("D3");
    }

    public void StartGame() // game start button
    {
        SceneManager.LoadScene("Level1");
    }

    public void EndGame()
    {
        Application.Quit();
    }
}