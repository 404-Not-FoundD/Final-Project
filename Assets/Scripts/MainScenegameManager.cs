using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneGameManager : MonoBehaviour
{
    public int hiScore = 0;

    public string scenename;
    public Text hiScoreText;
    
    public void Start()
    {
        //////////////////////////////////// high score do when level 5!!!!!!!!!!!!!!
        hiScore = int.Parse(StaticData.hiScoreToKeep);
        hiScoreText.text = hiScore.ToString("D3");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(scenename);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
