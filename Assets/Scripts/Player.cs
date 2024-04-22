using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float invincibleSpeedMultiplier = 2f; // 无敌状态下的移动速度加倍系数

    private CharacterController character;
    private Vector3 moveDirection = Vector3.zero;
    private bool isInvincible = false;

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
        moveDirection.x = horizontalInput * moveSpeed;

        if(!character.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if(isInvincible) // 如果处于无敌状态，加速移动
        {
            moveDirection *= invincibleSpeedMultiplier;
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
            // 如果處於無敵狀態，只需穿過障礙物和怪物，不造成任何效果
            return;
        }
        else if(other.CompareTag("aaa")) 
        {
            Debug.Log("invincible!");
            SetInvincible(true); // 將玩家設置為無敵模式
        }
        else if(!isInvincible) 
        {
            if(other.CompareTag("Obstacle") || other.CompareTag("Monster"))
            {
                // 如果不是無敵狀態，且與障礙物或怪物碰撞，則減少血量
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
        // 在这里你可以添加其他无敌状态相关的逻辑，比如改变玩家外观等
    }
}