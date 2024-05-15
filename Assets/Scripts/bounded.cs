using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    
    private Vector2 screenBounds;
    private float objectHalfHeight;
    private float objectHalfWidth;

    private void Awake()
    {
        objectHalfHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;// 物件高度一半
        objectHalfWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;// 物件寬度一半
        screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)
        );//得出來是負的，象限跟數學差正負號
    }

    private void LateUpdate()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(
            viewPosition.x,
            screenBounds.x * -1 + objectHalfWidth,
            screenBounds.x - objectHalfWidth
        );//Mathf.Clamp(a,b,c) a在bc之間回傳a，否則回傳bc中與a最相近的值
        viewPosition.y = Mathf.Clamp(
            viewPosition.y,
            screenBounds.y * -1 + objectHalfHeight,
            screenBounds.y - objectHalfHeight
        );
        transform.position = viewPosition;
    }
}