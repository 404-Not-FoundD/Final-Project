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
        IsInvincible = invincible;
        invincibleModeText.SetActive(true);

        if(invincibleCoroutine != null) // 已有一个无敌计时器在运行
        {
            StopCoroutine(invincibleCoroutine);
        }

        if(invincible)
        {
            invincibleCoroutine = StartCoroutine(InvincibleDurationCoroutine()); // 开始无敌计时器
        }
    }

    private IEnumerator InvincibleDurationCoroutine()
    {
        yield return new WaitForSeconds(invincibleModeDuration); // 等待无敌模式持续时间结束
        IsInvincible = false; // 结束无敌模式
        invincibleCoroutine = null; // 重置协程
        invincibleModeText.SetActive(false);
    }
}
