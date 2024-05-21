using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private float timeNow;
    private float waitDuration = 7f;    
    private bool MonsterAwake;

    private float distance_to_chase = 0.9f;
    private float speed = 1.5f;
    private float leftEdge;

    public PlayerManager playerManager;
    private DurationMode durationMode;

    public Rigidbody rb;
    public GameObject attackText;

    void Start()
    {
        durationMode = GetComponent<DurationMode>();

        timeNow = 0f;
        MonsterAwake = false;
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
                LeftEdge();
                durationMode.SetMode("DDoS", 3.0f, attackText);
                MonsterAwake = true;
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
        var targetPosition = position + new Vector3(direction.x, 0f, 0f);

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

    void LeftEdge()
    {
        // set the monster position to the left edge
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        transform.position = new Vector3(leftEdge, transform.position.y, 0);
    }
}