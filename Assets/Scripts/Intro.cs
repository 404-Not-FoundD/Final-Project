using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject introScreen;
    private float timeNow = 0f;
    private float introDuration = 2f;
    private bool introCompleted = false;

    void Update()
    {
        timeNow += Time.deltaTime;

        if(!introCompleted)
        {
            if(timeNow >= introDuration)
            {
                introScreen.SetActive(false);
                introCompleted = true;
            }
        } 
    }
}
