using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerManager playerManager;

    [SerializeField] private float distance_to_chase = 0.9f;
    public float speed = 0.8f;
    private float leftEdge;
    // private float scale = 0.3f;

    public float waitDuration = 7f;
    private float timeNow;    
    private bool MonsterAwake;

    void Start()
    {
        InitiateMonster();
    }

    void FixedUpdate()
    {
        timeNow += Time.deltaTime;

        if(!MonsterAwake)
        {
            if(timeNow >= waitDuration)
            {
                MonsterAwake = true;
            }
        }
        else
        {
            MonsterChasing();
        }
    }

    public void InitiateMonster()
    {
        timeNow = 0f;
        MonsterAwake = false;

        // set monster position to the left edge
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        Vector3 newPosition = transform.position;
        newPosition.x = leftEdge;
        transform.position = newPosition;
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
            if(direction.x<0)
            {
                // transform.localScale = new Vector3(-scale, scale, scale);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                // transform.localScale = new Vector3(scale, scale, scale);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            
            rb.MovePosition(Vector3.MoveTowards(position, targetPosition, speed * Time.fixedDeltaTime)); // for chasing
        }
    }
}