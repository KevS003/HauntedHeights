using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 initialPosition;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.2f;

    private Vector3 originalPosition;
    private bool shake = false;

    void Awake()
    {
        originalPosition = initialPosition; 
        transform.position = originalPosition;
    }

    void Update()
    {
        if (shake)
        {
            cameraTransform.position = originalPosition + Random.insideUnitSphere * shakeMagnitude;

        }
        else
        {
            cameraTransform.position = originalPosition;
        }
    }

    public void StartShake()
    {
        originalPosition = cameraTransform.position;
        shake = true;
    }
    public void StopShake()
    {
        shake = false;
    }
}
