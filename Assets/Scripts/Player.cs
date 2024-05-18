using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float invincibleSpeedMultiplier = 2f;
    public float decreaseSpeedMultiplier = 0.5f;

    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;

    private bool prestate = true; //0 L 1 R

    private CharacterController character;
    private DurationMode durationMode;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        character = GetComponent<CharacterController>();
        durationMode = GetComponent<DurationMode>();
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
        if(durationMode.IsInvincible)
        {
            moveDirection.x *= invincibleSpeedMultiplier;
        }
        else if(durationMode.IsSlow)
        {
            moveDirection.x *= decreaseSpeedMultiplier;
        }

        character.Move(moveDirection * Time.deltaTime);
    }

    private void HandleJump()
    {
        if(character.isGrounded && (Input.GetButtonDown("Jump") || Input.GetKey(KeyCode.UpArrow)))
        {
            moveDirection.y = jumpForce;
        }
    }
}
