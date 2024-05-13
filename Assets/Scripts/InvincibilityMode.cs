using System.Collections;
using UnityEngine;

public class InvincibilityMode : MonoBehaviour
{
    public float invincibleModeDuration = 5f;
    public bool IsInvincible {get; private set;}

    private Coroutine invincibleCoroutine = null;
    public GameObject invincibleModeText;

    public void SetInvincible(bool invincible)
    {
        // set invincible mode to be TRUE
        IsInvincible = invincible;
        invincibleModeText.SetActive(true);

        // if there exists other invincible timer running
        if(invincibleCoroutine != null)
        {
            StopCoroutine(invincibleCoroutine);
        }

        if(invincible)
        {
            // start the invincible timer
            invincibleCoroutine = StartCoroutine(InvincibleDurationCoroutine());
        }
    }

    private IEnumerator InvincibleDurationCoroutine()
    {
        yield return new WaitForSeconds(invincibleModeDuration); // wait mode to be ended
        IsInvincible = false;
        invincibleCoroutine = null;
        invincibleModeText.SetActive(false);
    }
}
