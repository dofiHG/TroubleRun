using UnityEngine;

public class CameraFolower : MonoBehaviour
{
    private Vector3 offset;
    private float smoothing = 5f;

    public Transform target;

    private void Start() => offset = transform.position - target.position;

    private void Update()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
