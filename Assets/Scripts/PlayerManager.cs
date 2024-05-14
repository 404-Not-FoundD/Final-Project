using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    
    public Vector3 Position
    {
        get { return playerTransform.position; }
    }
}
