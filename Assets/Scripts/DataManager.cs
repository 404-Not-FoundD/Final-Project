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

    private bool gameOver;
    public int gameOverScore;
    private float accTime = 0f;

    public Text scoreText;
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
        if(!gameOver) // wont affect(will dlt) when score is not keep by using time
        {
            TryTime();
            UpdateScoreText();
        }   
    }

    public void NewGame()
    {
        gameOver = false;
        if(SceneManager.GetActiveScene().name != "Level1")
        {
            UpdateDataFromStatic();
        } 
        else
        {
            hp = maxHp;
            UpdateHpBar();
        }

        if(gameOverScore > 0)
        {
            score = gameOverScore;
            gameOverScore = 0;
        }
    }

    void UpdateDataFromStatic()
    {
        score = int.Parse(StaticData.scoreToKeep);
        UpdateScoreText();

        hp = int.Parse(StaticData.lifeToKeep);
        UpdateHpBar();
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

    void UpdateScoreText()
    {
        scoreText.text = score.ToString("D3");
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

    public int GetHiScore()
    {
        if(score > hiScore)
        {
            return score;
        }
        return hiScore;
    }

    void TryTime()
    {
        accTime += Time.deltaTime; // Accumulate delta time
        
        // If accumulated time is at least 1 second, increase the score
        if (accTime >= 1.0f)
        {
            int increase = (int)accTime; // Convert accumulated time to an integer
            score += increase; // Add to the score
            accTime -= increase; // Reduce accumulated time by the integer amount
        }
    }
}
