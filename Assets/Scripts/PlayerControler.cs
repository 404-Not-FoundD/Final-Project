// This script is to keep track with the player's position
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Transform player;
    public float playerPosX;
    public float playerPosY;
    public bool magneticPlayer = false;

    public static PlayerControler instance;
    private DurationMode durationMode;

    public void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    void Start()
    {
        durationMode = GetComponent<DurationMode>();
    }

    void Update()
    {
        if(durationMode.IsMagnet) magneticPlayer = true;
        else magneticPlayer = false;

        playerPosX = player.position.x;
        playerPosY = player.position.y;
    }
}