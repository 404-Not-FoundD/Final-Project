using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public float gameSpeed {get; private set;}
    public float gameSpeedIncrease = 0.05f; 

    public bool gameOver {get; private set;}

    private DurationMode durationMode;
    public GameObject gameOverUI;
    public GameObject introScreen;

    private Player player;
    public string thisScene;
    
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
        durationMode = GetComponent<DurationMode>();
        player = FindFirstObjectByType<Player>();

        durationMode.SetMode("IntroScreen", 3.0f, introScreen);
        gameSpeed = 5f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(thisScene);
    }

    void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
    }

    public void GameOver()
    {
        gameOver = true;
        gameSpeed = 0f;

        gameOverUI.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
    }
}