// This script includes:
// - the animation of hitting the tree 
// - choosing the random apple 
// - instansiating the apple 
// - showing the status code

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeHit : MonoBehaviour
{
    [SerializeField] GameObject[] statusCodes;
    [SerializeField] GameObject gameManager;
    [SerializeField] float ShowTextSecs;
    public Sprite emptyTree;
    public GameObject instruction;
    public int maxHits;

    private bool animating;
    private bool isChosen = false;
    private GameObject uiObject;
    private DurationMode durationMode;
    
    private int appleIndex;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        Debug.Log(gameManager.name);
        durationMode = GetComponent<DurationMode>();
    }

    public void setChosen(bool okTree)
    {
        isChosen = okTree;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && maxHits != 0 && collision.gameObject.CompareTag("Player")) {
            Hit();
            findStatusCode(appleIndex);
            StartCoroutine("ShowStatusCode");
        }
    }

    void Hit()
    {
        DataManager.InstanceData.AddScore(1);
        
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        maxHits--;

        if (maxHits == 0) {
            Vector3 temp = transform.position;
            temp.y -= 0.5f;
            transform.position = temp;
            spriteRenderer.sprite = emptyTree;
            GetComponent<BoxCollider2D> ().enabled = false;
        }

        GameObject apple;
        if (isChosen) {
            apple = statusCodes[0]; // 0 must store 200ok
            appleIndex = 0;
        }
        else {
            appleIndex = Random.Range(1, statusCodes.Length);
            apple = statusCodes[appleIndex]; // From 1 is prob also okay
        }

        if (apple != null) {
            Vector3 position = transform.position;
            position.x -= 2f;
            position.y += 2.5f;
            Instantiate(apple, position, Quaternion.identity);
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

    private GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++) {
            if (objs[i].hideFlags == HideFlags.None) {
                if (objs[i].name == name) {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    void findStatusCode(int appleIndex)
    {
        switch(appleIndex) {
            case 0:
                uiObject = FindInActiveObjectByName("200Text");
                durationMode.SetMode("Instruction", 3.0f, instruction);
                break;
            case 1:
                uiObject = FindInActiveObjectByName("402Text");
                break;
            case 2:
                uiObject = FindInActiveObjectByName("102Text");
                break;
            case 3:
                uiObject = FindInActiveObjectByName("404Text");
                break;
            case 4:
                uiObject = FindInActiveObjectByName("418Text");
                break;
            case 5:
                uiObject = FindInActiveObjectByName("500Text");
                break;
            case 6:
                uiObject = FindInActiveObjectByName("503Text");
                break;
            case 7:
                uiObject = FindInActiveObjectByName("530Text");
                break;
        }
    }

    private IEnumerator ShowStatusCode()
    {
        uiObject.SetActive(true);
        yield return new WaitForSeconds(ShowTextSecs);
        uiObject.SetActive(false);
    }
}