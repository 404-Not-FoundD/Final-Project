using System.Collections;
using UnityEngine;

public class SlowMode : MonoBehaviour
{
    public float slowModeDuration = 2f;
    public bool IsSlow {get; private set;}

    private Coroutine slowCoroutine = null;

    public void SetSlow(bool slowMo)
    {
        IsSlow = slowMo;

        if(slowCoroutine != null)
        {
            StopCoroutine(slowCoroutine);
        }

        if(slowMo)
        {
            slowCoroutine = StartCoroutine(SlowDurationCoroutine());
        }
    }

    private IEnumerator SlowDurationCoroutine()
    {
        yield return new WaitForSeconds(slowModeDuration);
        IsSlow = false;
        slowCoroutine = null;
    }
}