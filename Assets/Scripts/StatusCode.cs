using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCode : MonoBehaviour
{
    private GameObject game_manager;
    private GameManager game_manager_script;
    public enum Type
    {
        NotFound, // like make dino 去背
        Ok, // green? idk
        Teapot, //if we have the time we can stuff dino into a teapot
        Frozen, // maybe freeze dino (just a costume)
        InternalServerError, 
        Unavailable, 
        Processing, // gives it a processing thing (also just a costume)
    }

    public Type type;

    void Awake()
    {
        game_manager = GameObject.Find("GameManager");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            Collect();
        }
    }

    void Collect()
    {
        switch (type) {
            case Type.Ok:
                Debug.Log("OK");
                game_manager_script = game_manager.GetComponent<GameManager>();
                game_manager_script.Get200();
                break;
        }

        Destroy(gameObject);
    }   
}