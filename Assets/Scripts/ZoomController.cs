using UnityEngine;
using Cinemachine;
using System.Collections;

public class ZoomController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float zoomInSize = 5f;
    public float zoomOutSize = 10f; // Default size
    public float zoomSpeed = 2f;

    private static bool isZooming = false; // Static variable to ensure only one zoom at a time

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isZooming) {
            StartCoroutine(ZoomCamera(zoomInSize));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isZooming) {
            StartCoroutine(ZoomCamera(zoomOutSize));
        }
    }

    private IEnumerator ZoomCamera(float targetSize)
    {
        isZooming = true;
        float initialSize = virtualCamera.m_Lens.OrthographicSize;
        float timeElapsed = 0f;

        while (timeElapsed < 1f) {
            // Find the orthographic size of the camera from initialSize to targetSize, based on time elapsed
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(initialSize, targetSize, timeElapsed);
            timeElapsed += Time.deltaTime * zoomSpeed;
            yield return null;
        }

        virtualCamera.m_Lens.OrthographicSize = targetSize;
        isZooming = false;
    }
}