using UnityEngine;

public class MoveThings : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public int speed;

    private int directionX;
    private int directionZ;
    public Vector3 rotateDirection;
    private void Start()
    {
        if (startPos.x != endPos.x) { directionX = 1; }
        if (startPos.z != endPos.z) { directionZ = 1; }
    }

    private void Update()
    {
        if (transform.position.x < startPos.x) { directionX = 1; }
        if (transform.position.x > endPos.x) { directionX = -1; }
        if (transform.position.z > endPos.z) { directionZ = 1; }
        if (transform.position.x > endPos.z) { directionZ = -1; }

        transform.Translate(new Vector3(directionX, 0, directionZ) * speed * Time.deltaTime);
        gameObject.transform.Rotate(rotateDirection);
    }
}
