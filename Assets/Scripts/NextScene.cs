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
            DataManager.InstanceData.AddScore(10);

            int score = DataManager.InstanceData.GetScore();
            StaticData.scoreToKeep = score.ToString();

            int hp = DataManager.InstanceData.GetHp();
            StaticData.lifeToKeep = hp.ToString();

            int time = DataManager.InstanceData.GetTime();
            StaticData.timeToKeep = time.ToString();

            SceneManager.LoadScene(scenename);
        }
    }

}