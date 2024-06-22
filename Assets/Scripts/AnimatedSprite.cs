using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int frame;
    private float speed;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    public void Animate()
    {
        frame++;

        if(frame >= sprites.Length)
        {
            frame = 0;
        }
        if(frame >= 0 && frame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[frame];
        }

        Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed);
    }
}