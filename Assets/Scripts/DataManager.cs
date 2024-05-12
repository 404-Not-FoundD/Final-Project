using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager InstanceData {get; private set;}

    public int maxHp = 7;
    public int hp;
    public int score;
    public int hiScore;
    public float time = 0f;

    private bool gameOver;
    public int gameOverScore;

    public Text scoreText;
    public Text timeText;
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
        NewGame();
    }

    void Update()
    {
        if(hp == 0)
        {
            gameOver = true;
            gameOverScore = score;
            GameManager.Instance.GameOver();
        }
        if(!gameOver)
        {
            time += Time.deltaTime;
            UpdateTimeText();
        }   
    }

    public void NewGame()
    {
        gameOver = false;
        if(SceneManager.GetActiveScene().name != "Level1")
        {
            UpdateDataFromStatic();
        } 
        else // first level
        {
            score = 0;
            hp = maxHp;
            time = 0f;
        }

        UpdateScoreText();
        UpdateHpBar();
        UpdateTimeText();
    }

    void UpdateDataFromStatic()
    {
        if(gameOverScore > 0)
        {
            score = gameOverScore;
            gameOverScore = 0;
        }
        else
        {
            score = int.Parse(StaticData.scoreToKeep);
        }
        hp = int.Parse(StaticData.lifeToKeep);
        time = int.Parse(StaticData.timeToKeep);   
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText();
    }

    public void ModifyHp(int amount)
    {
        hp += amount;
        hp = Mathf.Clamp(hp, 0, maxHp);
        UpdateHpBar();
    }

    void UpdateTimeText()
    {
        timeText.text = Mathf.FloorToInt(time).ToString("D3");
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString("D2");
    }

    void UpdateHpBar()
    {
        for(int i = 0; i < hpBar.transform.childCount; i++)
        {
            hpBar.transform.GetChild(i).gameObject.SetActive(i < hp);
        }
    }

    public int GetHp() 
    {
        return hp;
    }

    public int GetScore() 
    {
        return score;
    }

    public int GetTime()
    {
        return Mathf.FloorToInt(time);
    }

//////////////////////// best score can get only end game!!!!!!!!!!!!!!!!!!!!
    public int GetHiScore()
    {
        if(score < hiScore)
        {
            return score;
        }
        return hiScore;
    }
}