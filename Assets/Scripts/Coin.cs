using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform player;
    public bool startMagnet = false;

    private float distance;

    void OnBecameVisible()
    {
        startMagnet = true;
    }

    void OnBecameInvisible()
    {
        startMagnet = false;
    }

    void Update()
    {
        distance = Vector2.Distance(player.position, transform.position);
        if (distance <= 5) {
            // If player is in magnet mode, update coin's position
            if (PlayerControler.instance.magneticPlayer && startMagnet) {
                player.transform.position = new Vector3(PlayerControler.instance.playerPosX, PlayerControler.instance.playerPosY, 0);
                transform.position = Vector3.Lerp(transform.position, player.transform.position, 8 * Time.deltaTime);
            }
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            gameObject.SetActive(false);
            DataManager.InstanceData.AddScore(10);
        }
    }
}