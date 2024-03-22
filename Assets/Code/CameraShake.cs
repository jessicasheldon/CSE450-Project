using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeIntensity = 0.1f;
    public float shakeDuration = 0.5f;
   

    private Vector3 originalPosition;
    private bool isShaking = false;

    private void Awake()
    {
        originalPosition = transform.localPosition;
    }

    public void Shake()
    {
        if (!isShaking)
        {
            isShaking = true;
            InvokeRepeating("ApplyShake", 0, 0.01f);
            Invoke("StopShake", shakeDuration);
        }
    }

    private void ApplyShake()
    {
        Vector3 shakeOffset = Random.insideUnitSphere * shakeIntensity;
        transform.localPosition = originalPosition + shakeOffset;
    }

    public void StopShake()
    {
        CancelInvoke("ApplyShake");
        transform.localPosition = originalPosition;
        isShaking = false;
    }
}


   
