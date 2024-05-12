using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] normalSprites;
    public Sprite[] invincibleSprites;
    private Sprite[] currSprites;

    private SpriteRenderer spriteRenderer;
    private InvincibilityMode invincibilityMode;

    private int frame;

    void Awake()
    {
        currSprites = normalSprites;

        spriteRenderer = GetComponent<SpriteRenderer>();
        invincibilityMode = GetComponent<InvincibilityMode>();
    }

    void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Animate()
    {
        if(invincibilityMode.IsInvincible)
        {
            currSprites = invincibleSprites;
        }
        else
        {
            currSprites = normalSprites;
        }
        
        frame++;

        if(frame >= currSprites.Length) 
        {
            frame = 0;
        }

        if(frame >= 0 && frame < currSprites.Length)
        {
            spriteRenderer.sprite = currSprites[frame];
        }

        Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed);
    }
}
