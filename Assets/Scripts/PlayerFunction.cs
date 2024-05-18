using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerFunctions : MonoBehaviour
{
    public string nextscene;

    private DurationMode durationMode;
    public GameObject invincibilityText;

    void Start()
    {
        durationMode = GetComponent<DurationMode>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(!durationMode.IsInvincible)
        {
            // Player Modes
            if(other.CompareTag("Invincible"))
            {
                durationMode.SetMode("InvincibleMode", 5.0f, invincibilityText);
                DataManager.InstanceData.AddScore(10);
            }
            else if(other.CompareTag("SlowObstacle"))
            {
                durationMode.SetMode("SlowMode", 2.0f, null);
            } // freeze mode

            // Other Effects
            else if(other.CompareTag("Monster")) // Monster, life-1
            {
                DataManager.InstanceData.ModifyHp(-1);
            }
            else if(other.CompareTag("GuaiGuai")) // GuaiGuai, life+1
            {
                DataManager.InstanceData.ModifyHp(1);
                other.gameObject.SetActive(false);
            }
            else if(other.CompareTag("Tool"))
            {
                DataManager.InstanceData.AddScore(1);
            }
            
            // Levels Functions
            else if(other.CompareTag("GameOver")) // GameOver, life = 0
            {
                DataManager.InstanceData.ModifyHp(-7);
            }
            else if(other.CompareTag("NxtLevel"))
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
                SceneManager.LoadScene(nextscene);
            }
        }
    }
}
