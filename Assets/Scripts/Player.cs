using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float invincibleSpeedMultiplier = 2f; // 无敌状态下的移动速度加倍系数
    [SerializeField] private float invincibleModeDuration = 5f;

    private CharacterController character;
    private Vector3 moveDirection = Vector3.zero;
    private bool isInvincible = false;
    private Coroutine invincibleCoroutine = null;
    public GameObject invincibleModeText;

    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        moveDirection.x = horizontalInput * moveSpeed;

        if(!character.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if(isInvincible) // 如果处于无敌状态，加速移动
        {
            moveDirection.x *= invincibleSpeedMultiplier;
        }

        character.Move(moveDirection * Time.deltaTime);
    }

    void HandleJump()
    {
        if(character.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(isInvincible && other.CompareTag("Obstacle") || other.CompareTag("Monster"))
        {
            return;
        }
        else if(other.CompareTag("aaa")) 
        {
            SetInvincible(true); // 將玩家設置為無敵模式
            DataManager.InstanceData.AddScore(10);
            invincibleModeText.SetActive(true);
        }
        else if(!isInvincible) 
        {
            if(other.CompareTag("Obstacle") || other.CompareTag("Monster"))
            {
                DataManager.InstanceData.ModifyHp(-1);
            }
            else if(other.CompareTag("Coin"))
            {
                DataManager.InstanceData.ModifyHp(1);
            }
        }
    }

    void SetInvincible(bool invincible)
    {
        isInvincible = invincible;

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
        isInvincible = false; // 结束无敌模式
        invincibleCoroutine = null; // 重置协程
        invincibleModeText.SetActive(false);
    }
}