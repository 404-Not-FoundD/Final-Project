using UnityEngine;

public class shell : MonoBehaviour
{
    public GameObject shell_dialog;
    public GameObject text;
    public GameObject monster;

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") {
            shell_dialog.SetActive(true);
            text.SetActive(true);
            monster.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player") {
            shell_dialog.SetActive(false);
            text.SetActive(false);
            monster.SetActive(true);
        }
    }
}