using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextScene : MonoBehaviour
{
    private DurationMode durationMode;
    public string nextscene;

    void Start()
    {
        durationMode = GetComponent<DurationMode>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!durationMode.IsInvincible)
            {
                print("Is not invincible");
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
                SceneManager.LoadScene(nextscene);
            }
        }
    }
}