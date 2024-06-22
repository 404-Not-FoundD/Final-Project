// This script includes:
// - the animation of hitting the tree 
// - choosing a random apple 
// - instantiating the apple 
// - showing the status code

using System.Collections;
using UnityEngine;

public class CoconutTreeHit : MonoBehaviour
{
    public GameObject coconut;
    public int maxHits;
    private bool animating;

    void Awake()
    {
        coconut.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && maxHits != 0 && collision.gameObject.CompareTag("Player")) {
            Hit();
            coconut.SetActive(true);
        }
    }

    void Hit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        maxHits--;

        if (maxHits == 0) {
            GetComponent<BoxCollider2D>().enabled = false;
        }

        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        animating = true;

        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.left * 0.5f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        animating = false;
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.125f;

        while (elapsed < duration) {
            float t = elapsed / duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
    }
}