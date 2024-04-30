using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeData : MonoBehaviour
{
    public void BackHome()
    {
        int hiScore = DataManager.InstanceData.GetHiScore();
        StaticData.hiScoreToKeep = hiScore.ToString();

        SceneManager.LoadScene("MainScene");
    }
}
