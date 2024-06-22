using UnityEngine;

public class ActivateTerminal : MonoBehaviour
{
    public GameObject terminal;
    public GameObject lvText;
    public GameObject fixedCanvas;

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") {
            terminal.SetActive(true);
            lvText.SetActive(false);
            fixedCanvas.SetActive(false);
            Time.timeScale = 0f;
        }
    }  
}