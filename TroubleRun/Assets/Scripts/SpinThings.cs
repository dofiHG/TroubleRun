using UnityEngine;

public class SpinThings : MonoBehaviour
{
    public Vector3 rotateDirection;

    private void Update()
    {
        gameObject.transform.Rotate(rotateDirection);
    }
}
