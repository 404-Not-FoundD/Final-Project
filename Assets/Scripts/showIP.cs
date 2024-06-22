using UnityEngine;

public class box : MonoBehaviour
{
    public GameObject iptexts;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}