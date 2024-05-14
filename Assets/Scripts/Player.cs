using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;

    public float invincibleSpeedMultiplier = 2f;
    public float decreaseSpeedMultiplier = 0.5f;

    private bool prestate =true;//0 L 1 R

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

        // facing of the player (L / R)
        if(horizontalInput < 0 && prestate)
        {
            prestate = false;
        }
        else if(horizontalInput > 0 && !prestate)
        {
            prestate = true;
        }
        if(!prestate) transform.localScale = new Vector3(-1, 1, 1);
        else transform.localScale = new Vector3(1, 1, 1);

        // x-direction movement
        moveDirection.x = horizontalInput * moveSpeed;

        // player to be grounded
        if(!character.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // movement speed change
        if(invincibilityMode.IsInvincible)
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
        if(!invincibilityMode.IsInvincible)
        {
            if(other.CompareTag("Invincible")) 
            {
                invincibilityMode.SetInvincible(true);
                DataManager.InstanceData.AddScore(10);
            }
            else if(other.CompareTag("Monster")) // Monster, life-1
            {
                DataManager.InstanceData.ModifyHp(-1);
            }
            else if(other.CompareTag("Tool")) // Tool, score+1
            {
                DataManager.InstanceData.AddScore(1);
            }
            else if(other.CompareTag("GuaiGuai")) // GuaiGuai, life+1
            {
                DataManager.InstanceData.ModifyHp(1);
            }
            else if(other.CompareTag("SlowObstacle")) // Obstacle 1: get slow mo
            {
                slowMode.SetSlow(true);
            }
            // Obstacle 2: Freeze 3 sec
        }
    }
}