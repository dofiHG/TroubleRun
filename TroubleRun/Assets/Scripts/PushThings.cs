using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushThings : MonoBehaviour
{
    public float repelForce = 10f; // Сила отталкивания

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Проверяем, сталкивается ли объект с игроком
        {
            Vector3 repelDirection = (collision.transform.position - transform.position);
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            playerRigidbody.AddForce(repelDirection * repelForce, ForceMode.Impulse);
            Debug.Log(repelDirection.x);
            Debug.Log(repelDirection.y);
            Debug.Log(repelDirection.z);
        }
    }
}
