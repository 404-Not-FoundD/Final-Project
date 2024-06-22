using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class man : MonoBehaviour
{
    public GameObject Man;
    public GameObject shell_dialog;
    public GameObject text;
    public int man_version;
    public static int chosen_version;

    public void setChosen(int version)
    {
        chosen_version = version;
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") {
            if (man_version == chosen_version) {
                Man.gameObject.tag = "NxtLevel";
            }
            else {
                shell_dialog.SetActive(true);
                text.SetActive(true);
                DataManager.InstanceData.ModifyHp(-1);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            shell_dialog.SetActive(false);
            text.SetActive(false);           
        }
    }
}