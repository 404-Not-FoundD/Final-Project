using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager InstanceData {get; private set;}

    public Text scoreText, timeText;
    public GameObject hpBar, symbol;
    public int hp, score, guaiGuai, hiScore;
    public float limit_time, time, prevTime;

    private GameObject game_manager;
    private GameManager game_manager_script;

    void Awake()
    {
        game_manager = GameObject.Find("GameManager");

        if (InstanceData == null) {
            InstanceData = this;
        }
        else {
            DestroyImmediate(gameObject);
        }
    }

    void OnDestroy()
    {
        if (InstanceData == this) {
            InstanceData = null;
        }
    }

    void Start()
    {
        game_manager_script = game_manager.GetComponent<GameManager>();
        UpdateDataFromStatic();
        UpdateScoreText();
        UpdateTimeText();
        UpdateHpBar();
    }

    void Update()
    {
        if (!GameManager.Instance.gameOver) {
            // If no remaining life, game over
            if (hp == 0) GameManager.Instance.GameOver();

            // If exceeds time limit, game over (Level 5)
            if (game_manager_script.thisScene == "Level5") {
                time -= Time.deltaTime;
                if (time <= 0) {
                    time = 0;
                    GameManager.Instance.GameOver();
                }
                else if (time <= 10) {
                    timeText.color = Color.red;
                }
                else {
                    timeText.color = Color.white;
                }
            }
            else {
                timeText.color = Color.white;
                time += Time.deltaTime;
            }

            UpdateTimeText();
        }
    }

    void UpdateDataFromStatic()
    {
        // Initialize every data to default value
        guaiGuai = score = 0;
        hp = 7;
        time = prevTime = 0f;

        // change data if staticData script has value stored
        if (StaticData.scoreToKeep != null) {
            score = int.Parse(StaticData.scoreToKeep);
        }

        if (StaticData.timeToKeep != null) {
            time = int.Parse(StaticData.timeToKeep);
            hp = int.Parse(StaticData.lifeToKeep);
        }

        // Initiate time (Level 5)
        if (game_manager_script.thisScene == "Level5") {
            prevTime = time;
            time = limit_time;
        }  
    }

    void UpdateScoreText()
    {
        // If score is negative, '+'symbol won't show
        if (score < 0) symbol.gameObject.SetActive(false);
        else symbol.gameObject.SetActive(true);

        scoreText.text = score.ToString("D2");
    }

    void UpdateTimeText()
    {
        timeText.text = Mathf.FloorToInt(time).ToString("D3");
    }

    void UpdateHpBar()
    {
        for (int i = 0; i < hpBar.transform.childCount; i++) {
            hpBar.transform.GetChild(i).gameObject.SetActive(i < hp);
        }
    }

    // Functions that can be called by other script
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText();
    }

    public void ModifyHp(int amount)
    {
        hp += amount;
        hp = Mathf.Clamp(hp, 0, 7);
        UpdateHpBar();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetTime()
    {
        return Mathf.FloorToInt(time);
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetGuaiGuai(int count)
    {
        guaiGuai += count;
        return guaiGuai;
    }

    public int GetHiScore()
    {
        float hiScoreFloat = score * 0.5f - prevTime * 0.2f + time * 0.1f;
        int hiScoreNow = Mathf.FloorToInt(hiScoreFloat);

        if (StaticData.hiScoreToKeep != null) {
            hiScore = int.Parse(StaticData.hiScoreToKeep);
            if (hiScoreNow > hiScore) hiScore = hiScoreNow;
        }
        else {
            hiScore = hiScoreNow;
        }

        return hiScore;
    }
}