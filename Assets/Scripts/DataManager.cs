using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager InstanceData {get; private set;}

    public int hp;
    public int score;
    public float time;

    public Text scoreText, timeText;
    public GameObject hpBar;

    void Awake()
    {
        if(InstanceData == null) 
        {
            InstanceData = this;
        }
        else 
        {
            DestroyImmediate(gameObject);
        }
    }

    void OnDestroy()
    {
        if(InstanceData == this) 
        {
            InstanceData = null;
        }
    }

    void Start()
    {
        
        // (COULD TEMPORARY NOT USING THIS CODE FOR lvl's TRIES) ********
        if(SceneManager.GetActiveScene().name != "Level1")
        {
            UpdateDataFromStatic();
        } 
        else
        {
            score = 0;
            time = 0f;
            hp = 7;
        }
        /*
        score = 0;
        time = 0f;
        hp = 7;
        */

        UpdateScoreText();
        UpdateTimeText();
        UpdateHpBar();
    }

    void Update()
    {
        if(hp == 0)
        {
            GameManager.Instance.GameOver();
        }

        if(!GameManager.Instance.gameOver)
        {
            time += Time.deltaTime;
            UpdateTimeText();
        }   
    }

    void UpdateDataFromStatic()
    {
        score = int.Parse(StaticData.scoreToKeep);
        time = int.Parse(StaticData.timeToKeep); 
        hp = int.Parse(StaticData.lifeToKeep);  
    }

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

    void UpdateScoreText()
    {
        scoreText.text = score.ToString("D2");
    }

    void UpdateTimeText()
    {
        timeText.text = Mathf.FloorToInt(time).ToString("D3");
    }

    void UpdateHpBar()
    {
        for(int i = 0; i < hpBar.transform.childCount; i++)
        {
            hpBar.transform.GetChild(i).gameObject.SetActive(i < hp);
        }
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

//////////////////////// best score can only get when end game (LVL5)>>>>>(pending to update!!)
/*
    public int GetHiScore()
    {
        if(score < hiScore)
        {
            return score;
        }
        return hiScore;
    }
*/
}