using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell_dif : MonoBehaviour
{
    public GameObject shell_dialog;
    public GameObject[] unique1;
    public GameObject[] unique2;
    public GameObject[] unique3;
    public GameObject[] same12;
    public GameObject[] same13;

    public int shell_num; // 1-unique, 2-double same
    private static int chosen_version;

    public GameObject monster;
    private GameObject gamemanager;
    private GameObject tmp;
    
    void Awake()
    {
        gamemanager = GameObject.Find("GameManager");
    }

    public void setChosen(int version)
    {
        chosen_version = version;
    }
    
    private GameObject the_text(int shell_num,int chossen_version)
    {
        if(chosen_version == 0) {
            if (shell_num == 1) {
                return unique1[0];
            }
            else {
                int kind = Random.Range(1, 3);

                if (kind == 1) return same12[Random.Range(0, same12.Length)];
                else return same13[Random.Range(0,same13.Length)];
            }
        }
        else if (chosen_version == 1) {
            if (shell_num == 1) {
                return unique2[Random.Range(0, unique2.Length)];
            }
            else {
                return same12[Random.Range(0, same12.Length)];
            }
        }
        else {
            if (shell_num == 1) 
            {
                return unique3[Random.Range(0, unique3.Length)];
            }
            else {
                return same13[Random.Range(0, same13.Length)];            
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") {
            shell_dialog.SetActive(true);
            tmp = the_text(shell_num, chosen_version);
            tmp.SetActive(true);
            monster.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player") {
            shell_dialog.SetActive(false);
            tmp.SetActive(false);
            monster.SetActive(true);
        }
    }
}