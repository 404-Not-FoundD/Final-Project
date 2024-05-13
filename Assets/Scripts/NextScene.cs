using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextScene : MonoBehaviour
{
    public Text score;
    public string scenename;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // score +10
            DataManager.InstanceData.AddScore(10);

            // get data from DataManagerScript
            int score = DataManager.InstanceData.GetScore();
            int hp = DataManager.InstanceData.GetHp();
            int time = DataManager.InstanceData.GetTime();

            // store data to StaticDataScript
            StaticData.scoreToKeep = score.ToString();
            StaticData.lifeToKeep = hp.ToString();
            StaticData.timeToKeep = time.ToString();

            // to the next scene
            SceneManager.LoadScene(scenename);
        }
    }
}