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
            hiScore = GetHiScore();
            GameManager.Instance.GameOver();
        }
    }

    public void NewGame()
    {
        if(SceneManager.GetActiveScene().name != "Level1")
        {
            UpdateDataFromStatic();
        } 
        else
        {
            hp = maxHp;
            UpdateHpBar();
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
}
