using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiltcontrol : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(moveVertical * speed, 0, -moveHorizontal * speed);
        Quaternion deltaRotation = Quaternion.Euler(moveVector * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
