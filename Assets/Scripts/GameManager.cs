using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver {get; private set;}
    public static GameManager Instance {get; private set;}

    public GameObject gameOverUI;
    public GameObject introScreen;
    public string thisScene;

    private DurationMode durationMode;
    private Player player;

//<<<<<<< HEAD
    public bool canClear;
/*=======
>>>>>>> 9c534b2e700fc7ae09bf0dc2ff7c9f100084f8ee*/
    
    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else {
            DestroyImmediate(gameObject);
        }
//<<<<<<< HEAD
        canClear = false;
/*=======
>>>>>>> 9c534b2e700fc7ae09bf0dc2ff7c9f100084f8ee*/
    }

    void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    void Start()
    {
        durationMode = GetComponent<DurationMode>();
        player = FindFirstObjectByType<Player>();

        durationMode.SetMode("IntroScreen", 4.0f, introScreen);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(thisScene);
    }

    public void GameOver()
    {
        gameOver = true;

        gameOverUI.gameObject.SetActive(true);
        player.gameObject.SetActive(false);

        // Update static data score by minus 5 whenever get game over
        int score;
        if(StaticData.scoreToKeep == null) score = -5;
        else score = int.Parse(StaticData.scoreToKeep) - 5;

        StaticData.scoreToKeep = score.ToString();
    }

//<<<<<<< HEAD
    public void Get200()
    {
        canClear = true;
        Debug.Log(canClear);
    }
/*=======
>>>>>>> 9c534b2e700fc7ae09bf0dc2ff7c9f100084f8ee*/
}