using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerManager playerManager;

    public float speed = 1f;

    private void FixedUpdate()
    {
        var playerPosition = playerManager.Position;
        var position = transform.position;
        var direction = (playerPosition - position).normalized;
        var targetPosition = position + new Vector3(direction.x, 0f, 0f); // Movement only on x-axis
        rb.MovePosition(Vector3.MoveTowards(position, targetPosition, speed * Time.fixedDeltaTime));
    }
}