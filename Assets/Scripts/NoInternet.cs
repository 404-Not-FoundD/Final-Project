using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoInternet : MonoBehaviour
{
    public AudioSource jump_music;

    void Start()
    {
        jump_music.playOnAwake = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) {
            jump_music.Play();
            StartCoroutine(Jump(transform.localPosition, transform.localPosition + Vector3.up * 0.5f));
            
        }
        
    }

    private IEnumerator Jump(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.125f;
        // Continue the loop until the elapsed time reaches the duration (0.125s)
        while (elapsed < duration) {
        
            float t = elapsed / duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }
        

        transform.localPosition = to;
        SceneManager.LoadScene("Level1");

    }  
}