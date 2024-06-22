using System.Collections;
using UnityEngine;

public class guaiguai : MonoBehaviour
{
    protected AudioSource family_music;

    void Start() 
    {
        family_music = GetComponent<AudioSource>();
        family_music.playOnAwake = false; // Ensure audio won't play automatically when the scene loads

        // Debug log to ensure the audio is correctly loaded
        if (family_music.clip != null) {
            Debug.Log("Audio clip loaded: " + family_music.clip.name);
        } 
        else {
            Debug.LogError("Audio clip not found!");
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        // Check whether the collider is player
        if (other.CompareTag("Player")) {
            family_music.Play();
            Debug.Log("Audio started playing");
            StartCoroutine(HideAfterSound());
        }
    }

    private IEnumerator HideAfterSound() 
    {
        // Wait for the audio to finish playing
        if (family_music.clip != null) {
            yield return new WaitForSeconds(family_music.clip.length);
        } 
        else {
            Debug.LogError("No audio clip to play");
        }
        
        // hide the game object
        gameObject.SetActive(false);
        Debug.Log("GameObject hidden");
    }
}