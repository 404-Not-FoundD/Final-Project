using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public float gameSpeed {get; private set;}
    public float gameSpeedIncrease = 0.05f; 

    public GameObject gameOverUI;
    private Player player;
    private GameObject[] guaiGuais;

    void Awake()
    {
        if(Instance == null) 
        {
            Instance = this;
        }
        else 
        {
            DestroyImmediate(gameObject);
        }
        
        guaiGuais = GameObject.FindGameObjectsWithTag("GuaiGuai");
    }

    void OnDestroy()
    {
        if(Instance == this) 
        {
            Instance = null;
        }
    }

    void Start()
    {
        player = FindFirstObjectByType<Player>();
        NewGame();
    }

    public void NewGame()
    {
        gameSpeed = 5f;

        foreach (GameObject guaiGuai in guaiGuais)
        {
            guaiGuai.SetActive(true);
        }

        player.gameObject.SetActive(true);
        gameOverUI.gameObject.SetActive(false);
    }

    void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        player.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
    }
}