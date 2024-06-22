using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class man_4 : MonoBehaviour
{
    public GameObject panel;
    public GameObject text;
    public GameObject monster;

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") {
            panel.SetActive(true);
            text.SetActive(true);
            monster.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            panel.SetActive(false);
            text.SetActive(false);   
            monster.SetActive(true);        
        }
    }
}