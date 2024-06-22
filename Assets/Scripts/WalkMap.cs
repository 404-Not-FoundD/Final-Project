using UnityEngine;

public class WalkMap : MonoBehaviour
{
    private Transform player;
    private Player playerScript; // Refer to the Player script

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerScript = player.GetComponent<Player>(); 
    }
    
    void LateUpdate()
    {
        walkmap();
    }

    // Modified walkmap function to accept horizontal_move value
    public void walkmap()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = player.position.x;
        transform.position = cameraPosition;
    }
}