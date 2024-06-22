using UnityEngine;

public class Instruction : MonoBehaviour
{
    private DurationMode durationMode;
    public GameObject instructText;

    void Start()
    {
        durationMode = GetComponent<DurationMode>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If player collides, get instruction screen
        if (other.CompareTag("Player")) {
            durationMode.SetMode("Instructions", 2.0f, instructText);
        }
    }
}