using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;

    public float invincibleSpeedMultiplier = 2f;
    public float decreaseSpeedMultiplier = 0.5f;

    private CharacterController character;
    private Vector3 moveDirection = Vector3.zero;
    private InvincibilityMode invincibilityMode;
    private SlowMode slowMode;

    void Start()
    {
        character = GetComponent<CharacterController>();
        invincibilityMode = GetComponent<InvincibilityMode>();
        slowMode = GetComponent<SlowMode>();
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

        if(invincibilityMode.IsInvincible) // 如果处于无敌状态，加速移动
        {
            moveDirection.x *= invincibleSpeedMultiplier;
        }
        else if(slowMode.IsSlow)
        {
            moveDirection.x *=decreaseSpeedMultiplier;
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
        if(other.CompareTag("Invincible")) 
        {
            invincibilityMode.SetInvincible(true);
            DataManager.InstanceData.AddScore(10);
        }
        else if(!invincibilityMode.IsInvincible) 
        {
            if(other.CompareTag("Monster"))
            {
                DataManager.InstanceData.ModifyHp(-1);
            }
            else if(other.CompareTag("Tool"))
            {
                DataManager.InstanceData.ModifyHp(1);
            }
            else if(other.CompareTag("SlowObstacle"))
            {
                slowMode.SetSlow(true);
            }
        }
    }
}