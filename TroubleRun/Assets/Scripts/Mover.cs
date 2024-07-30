using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public bool isGround;

    private float horizontalDirection;
    private float verticalDirection;
    private Rigidbody rb;
    private LayerMask layerMask;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        int angle = 90;
        int temp = 1;

        horizontalDirection = Input.GetAxis("Horizontal");
        verticalDirection = Input.GetAxis("Vertical");

        transform.position += Vector3.right * horizontalDirection * speed * Time.deltaTime;
        transform.position += Vector3.forward * verticalDirection * speed * Time.deltaTime;
        
        if (verticalDirection < 0 && horizontalDirection != 0) { temp = -1; }
        transform.rotation = Quaternion.Euler(0, (horizontalDirection * angle + (verticalDirection * angle - 90) * verticalDirection) * temp, 0);

        
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        Physics.Raycast(ray, out hit, 1f);

        if (hit.collider && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }
}
