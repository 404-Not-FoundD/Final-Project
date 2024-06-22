using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerFunctions : MonoBehaviour
{
    public GameObject invincibilityText;
    public GameObject data_manager;
    public GameObject shell_panel;
    public GameObject magnet_collider;
    private GameObject game_manager;

    public AudioSource guaiguai;
    private GameManager game_manager_script;
    private DataManager data_manager_script;
    private Player player_script;
    private DurationMode durationMode;

    public string nextscene;
    public int money_to_collect;
    public int pre_coin = 15;
    private int family_mart_cost = 50;
    private int guaiGuaiCount = 3;
    private bool pass = false;  


    void Awake()
    {
        game_manager = GameObject.Find("GameManager");
        data_manager = GameObject.Find("DataManager");
    }

    void Start()
    {
        durationMode = GetComponent<DurationMode>();
        game_manager_script = game_manager.GetComponent<GameManager>();
        data_manager_script = data_manager.GetComponent<DataManager>();
        player_script = this.GetComponent<Player>();
        guaiguai.playOnAwake = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Player's functions when trigger specific object
        if (!durationMode.IsInvincible && !durationMode.IsMagnet) {
            if (other.CompareTag("SlowObstacle")) {
                durationMode.SetMode("SlowMode", 2.0f, null);
            }
            else if (other.CompareTag("Monster")) {
                DataManager.InstanceData.ModifyHp(-1);
            }
            else if (other.tag == "GuaiGuai") {
                guaiguai.Play();
                other.gameObject.SetActive(false);
                DataManager.InstanceData.ModifyHp(1);
                DataManager.InstanceData.AddScore(1);

                if (DataManager.InstanceData.GetGuaiGuai(1) % guaiGuaiCount == 0) {
                    durationMode.SetMode("InvincibleMode", 5.0f, invincibilityText);
                    DataManager.InstanceData.AddScore(10);
                }
            }

            // Other functions in different levels
            else if (other.tag == "shell") {
                shell_panel.SetActive(true);
            }
            else if (other.tag == "family_mart") {
                data_manager_script.time -= 5f;
                DataManager.InstanceData.AddScore(-family_mart_cost);
            }
            else if (other.CompareTag("door")) {
                data_manager_script.time += 10f;
            }
            else if (other.CompareTag("magnet")) {
                other.gameObject.SetActive(false);
                DataManager.InstanceData.AddScore(1);
                durationMode.SetMode("MagneticMode", 5.0f, null);
            }
            else if (other.tag == "Coin") {
                other.gameObject.SetActive(false);
                Debug.Log("Coin");
                DataManager.InstanceData.AddScore(pre_coin);
            }
            else if(other.tag == "sushi"){
                other.gameObject.SetActive(false);
                DataManager.InstanceData.AddScore(100);
            }

            // Levels Functions
            else if (other.CompareTag("Restart")){
                game_manager_script.RestartGame();
            }
            else if (other.CompareTag("NxtLevel")) {
                pass = check_pass(game_manager_script.thisScene);
                Debug.Log(pass);

                // If pass the level
                if (pass == true) {
                    DataManager.InstanceData.AddScore(10);

                    if (SceneManager.GetActiveScene().name == "Level5") {
                        int hiScore = DataManager.InstanceData.GetHiScore();
                        StaticData.hiScoreToKeep = hiScore.ToString();
                    }

                    // Get data from DataManagerScript
                    int score = DataManager.InstanceData.GetScore();
                    int hp = DataManager.InstanceData.GetHp();
                    int time = DataManager.InstanceData.GetTime();

                    // Store data to StaticDataScript
                    StaticData.scoreToKeep = score.ToString();
                    StaticData.lifeToKeep = hp.ToString();
                    StaticData.timeToKeep = time.ToString();

                    // Next scene
                    SceneManager.LoadScene(nextscene);
                }
                else {
                    game_manager_script.RestartGame();
                }
               
            }
        }
        else if (durationMode.IsMagnet) {
            if (other.tag == "Coin") {
                other.gameObject.SetActive(false);
                DataManager.InstanceData.AddScore(10);
            }
        }
    }

    bool check_pass(string Level)
    {
        if (Level == "Level1") {
            if(game_manager_script.canClear == true) return true;
        }
        else if (Level == "Level2" || Level == "Level3" || Level == "Level4") {
            return true;
        }
        else if (Level == "Level5") {
            if (data_manager_script.GetScore() > money_to_collect) return true;
        }
        return false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "shell") {
            shell_panel.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "ground") {
            player_script.jumpCount = 0;
            Debug.Log("Touch ground");
        }
    }
}