using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSlippery : MonoBehaviour
{
    public int iceDrag = 0;
    public int normalDrag = 5;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = normalDrag;
    }


    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("ICE");
        if (collision.collider.CompareTag("Ice"))
        {
            rb.drag = iceDrag;
        }

    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.collider.CompareTag("Ice"))
        {
            rb.drag = normalDrag;
        }

    }
}
