using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private float timeNow;
    private float waitDuration = 7f;    
    private bool MonsterAwake;

    private float distance_to_chase = 0.9f;
    private float speed = 0.8f;
    private float leftEdge;

    public Rigidbody rb;
    public PlayerManager playerManager;
    public GameObject attackText;

    private DurationMode durationMode;

    void Start()
    {
        durationMode = GetComponent<DurationMode>();

        timeNow = 0f;
        MonsterAwake = false;

        // set the monster position to the left edge
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        transform.position = new Vector3(leftEdge, transform.position.y, 0);
    }

    void FixedUpdate()
    {
        if(GameManager.Instance.gameOver)
        {
            return;
        }

        timeNow += Time.deltaTime;

        if(!MonsterAwake)
        {
            if(timeNow >= waitDuration)
            {
                MonsterAwake = true;
                durationMode.SetMode("DDoS", 3.0f, attackText);
            }
        }
        else
        {
            MonsterChasing();
        }
    }

    void MonsterChasing()
    {
        var playerPosition = playerManager.Position;
        var position = transform.position;
        var direction = (playerPosition - position).normalized;
        var targetPosition = position + new Vector3(direction.x, 0f, 0f); // Movement only on x-axis

        if(Mathf.Abs(playerPosition.x - position.x) > distance_to_chase)
        {
            //change the facing of monster
            if(direction.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
             
            rb.MovePosition(Vector3.MoveTowards(position, targetPosition, speed * Time.fixedDeltaTime)); // for chasing
        }
    }
}