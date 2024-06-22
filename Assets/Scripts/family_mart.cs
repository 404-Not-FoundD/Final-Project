using System.Collections;
using UnityEngine;

public class family_mart : MonoBehaviour
{
    protected AudioSource family_music;

    void Start()
    {
        family_music = GetComponent<AudioSource>();
        family_music.playOnAwake = false; // Ensure audio won't play automatically when the scene loads
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check whether the collider is player
        if (other.CompareTag("Player")) {
            family_music.Play();
        }
    }
}