using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject HelpMenuUI;
    public GameObject InfoMenuUI;
    private bool GameIsPaused;
    private bool MenuIsActive;
    public void pause(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void home(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
    public void quit(){
        Debug.Log("quit");
        Application.Quit();
    }
    public void help(){
        HelpMenuUI.SetActive(true);
        MenuIsActive = true;
    }
    public void info(){
        InfoMenuUI.SetActive(true);
        MenuIsActive = true;
    }
    public void github(){
        Application.OpenURL("https://github.com/404-Not-FoundD/Final-Project");
    }
    void Update(){
        if(GameIsPaused && MenuIsActive && Input.GetKeyDown(KeyCode.Escape)){
            InfoMenuUI.SetActive(false);
            HelpMenuUI.SetActive(false);
            MenuIsActive = false;
        }
    }
}
