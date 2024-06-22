using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 3f;
    public float jumpForce = 6f;
    private float speedMultiplier = 1f;
    private float invincibleSpeedMultiplier = 2f;
    private float decreaseSpeedMultiplier = 0.5f;
    
    public int jumpCount; 
    public int maxJumps = 1; 
    public Transform ground_check;
    public LayerMask groundLayer; // LayerMask to specify what count as ground
    public AudioSource jump_music;

    private DurationMode durationMode;
    private GameManager game_manager_script;
    private GameObject game_manager;
    private bool isGrounded;
    

    void Awake()
    {
        game_manager = GameObject.Find("GameManager");
    }

    void Start()
    {
        durationMode = GetComponent<DurationMode>();
        game_manager_script = game_manager.GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();

        transform.localScale = new Vector3(1, 1, 1); // Set the scale of player
        jump_music.playOnAwake = false;
    }

    void FixedUpdate()
    {
        movement();
        fall_gameOver();
        isGrounded = Physics2D.OverlapCircle(ground_check.position, 0.2f, groundLayer);
    }

    void Update() 
    {
        jump();
    }

    void movement()
    {
        float horizontal_move = Input.GetAxis("Horizontal");
        
        // Check if the player is grounded
        var v = rb.velocity;
        v.x = 0;
        rb.velocity = v;
        
        if (horizontal_move != 0) {
            // Movement speed change
            if (durationMode.IsInvincible) speedMultiplier = invincibleSpeedMultiplier;
            else if (durationMode.IsSlow) speedMultiplier = decreaseSpeedMultiplier;
            else speedMultiplier = 1f;

            // Set player's velocity
            rb.velocity = new Vector2(horizontal_move * moveSpeed * speedMultiplier, rb.velocity.y);

            // Change player's direction visually
            transform.localScale = new Vector3(Mathf.Sign(horizontal_move), 1, 1);
        } 
    }

    void jump()
    {
        if (isGrounded) {
            jumpCount = 0; // Reset jump count when grounded
        }
        if ((Input.GetButtonDown("Jump") || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && jumpCount < maxJumps) {
            rb.velocity = Vector2.up * jumpForce;
            jumpCount++;
            jump_music.Play();
        }
        if ((Input.GetButtonDown("Jump") || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && jumpCount == maxJumps && isGrounded) {
            rb.velocity = Vector2.up * jumpForce;
            jump_music.Play();
        }
    }

    void fall_gameOver()
    {
        if (transform.position.y < -20f) {
            game_manager_script.GameOver();
        }
    }
}