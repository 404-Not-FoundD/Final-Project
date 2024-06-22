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

        if (objectText != null) {
            objectText.gameObject.SetActive(true);
        }

        // Stop any existing coroutine if it is running
        if (modeCoroutine != null) {
            StopCoroutine(modeCoroutine);
        }

        // Start a new coroutine for the mode duration
        modeCoroutine = StartCoroutine(ModeDurationCoroutine());
    }

    private IEnumerator ModeDurationCoroutine()
    {
        float elapsed = 0f;

        while (elapsed < modeDuration) {
            if (GameManager.Instance.gameOver) break;

            elapsed += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        if (objectText != null) {
            objectText.gameObject.SetActive(false);
        }

        modeString = null;
        modeCoroutine = null;
    }

    // Functions that can be called by other script
    public bool IsInvincible
    {
        get {return modeString == "InvincibleMode";}
    }

    public bool IsSlow
    {
        get {return modeString == "SlowMode";}
    }

    public bool IsMagnet
    {
        get {return modeString == "MagneticMode";}
    }
}