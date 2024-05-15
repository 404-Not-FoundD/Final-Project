using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeData : MonoBehaviour
{
    public void BackHome()
    {
        /******* WHAT DATA SHOULD I KEEP?*********
        // get the best score from DataManagerScript (int type)
        int hiScore = DataManager.InstanceData.GetHiScore();

        // keep data to StaticDataScript (string type)
        StaticData.hiScoreToKeep = hiScore.ToString();
        */
        
        SceneManager.LoadScene("MainScene");
    }
}