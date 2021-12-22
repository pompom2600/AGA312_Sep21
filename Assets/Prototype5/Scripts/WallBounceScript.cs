using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounceScript : MonoBehaviour
{
    public int speed = 5;
    public Rigidbody PlayerRb;
    Vector3 lastVelocity;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        lastVelocity = PlayerRb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bounce"))
        {
            //lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            PlayerRb.velocity = direction * Mathf.Max(speed, 0); 
        }

    }
}
