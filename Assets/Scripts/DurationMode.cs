using System.Collections;
using UnityEngine;

public class DurationMode : MonoBehaviour
{
    public string modeString {get; private set;}

    private float modeDuration;
    private GameObject objectText;
    private Coroutine modeCoroutine = null;

    public void SetMode(string mode, float duration, GameObject text)
    {
        modeString = mode;
        modeDuration = duration;
        objectText = text;

        if(objectText != null)
        {
            objectText.gameObject.SetActive(true);
        }

        // Stop any existing coroutine if it is running
        if(modeCoroutine != null)
        {
            StopCoroutine(modeCoroutine);
        }

        // Start a new coroutine for the mode duration
        modeCoroutine = StartCoroutine(ModeDurationCoroutine());
    }

    private IEnumerator ModeDurationCoroutine()
    {
        yield return new WaitForSeconds(modeDuration);

        if(objectText != null)
        {
            objectText.gameObject.SetActive(false);
        }

        modeString = null;
        modeCoroutine = null;
    }

    public bool IsInvincible
    {
        get {return modeString == "InvincibleMode";}
    }

    public bool IsSlow
    {
        get {return modeString == "SlowMode";}
    }
}
