using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager InstanceData {get; private set;}

    public int hp, score, guaiGuai;
    public float time;

    public Text scoreText, timeText;
    public GameObject hpBar, symbol;

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
        UpdateDataFromStatic();
        UpdateScoreText();
        UpdateTimeText();
        UpdateHpBar();
    }

    void Update()
    {
        if(!GameManager.Instance.gameOver)
        {
            if(hp == 0)
            {
                // manually update static data be score minus 5
                if(StaticData.scoreToKeep == null)
                {
                    score = -5;
                }
                else
                {
                    score = int.Parse(StaticData.scoreToKeep) - 5;
                }
                StaticData.scoreToKeep = score.ToString();
                
                GameManager.Instance.GameOver();
            }
            time += Time.deltaTime;
            UpdateTimeText();
        }   
    }

    void UpdateDataFromStatic()
    {
        guaiGuai = score = 0;
        time = 0f;
        hp = 7;

        if(StaticData.scoreToKeep != null)
        {
            score = int.Parse(StaticData.scoreToKeep);
        }

        if(StaticData.timeToKeep != null)
        {
            time = int.Parse(StaticData.timeToKeep); 
            hp = int.Parse(StaticData.lifeToKeep); 
        } 
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
        if(score < 0)
        {
            symbol.gameObject.SetActive(false);
        }
        else
        {
            symbol.gameObject.SetActive(true);
        }
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

    public int GetGuaiGuai(int count)
    {
        guaiGuai += count;
        return guaiGuai;
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