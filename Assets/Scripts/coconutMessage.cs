using UnityEngine;
using TMPro;

public class coconutmessage : MonoBehaviour
{
    public GameObject coconut_panel;
    public TextMeshProUGUI text;
    public GameObject monster;

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") {
            coconut_panel.SetActive(true);
            text.enabled = true;
            text.gameObject.SetActive(true);
            monster.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") {
            coconut_panel.SetActive(false);
            text.enabled = false;
            monster.SetActive(true);
        }
    }
}