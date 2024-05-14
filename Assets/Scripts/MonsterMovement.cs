using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerManager playerManager;

    public float speed = 0.8f;
    private float scale = 0.3f;
    private void FixedUpdate()
    {
        var playerPosition = playerManager.Position;
        var position = transform.position;
        var direction = (playerPosition - position).normalized;
        var targetPosition = position + new Vector3(direction.x, 0f, 0f); // Movement only on x-axis
        if(direction.x<0){
            transform.localScale = new Vector3(-scale, scale, scale);
        }
        else{
            transform.localScale = new Vector3(scale, scale, scale);
        }
        rb.MovePosition(Vector3.MoveTowards(position, targetPosition, speed * Time.fixedDeltaTime));
    }
}