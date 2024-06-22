using UnityEngine;

public class Instruction : MonoBehaviour
{
    private DurationMode durationMode;
    public GameObject instructText;

    void Start()
    {
        durationMode = GetComponent<DurationMode>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            {
                durationMode.SetMode("Instructions", 2.0f, instructText);
            }
        }
    }
}
