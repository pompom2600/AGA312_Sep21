using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TiltControl : MonoBehaviour
{
    [Header("Platform")]
    public float speed = 20f;
    Rigidbody rB;

    [Header("Other")]
    public float tweenTime = 1f;
    public GameObject egg;

    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Mathf.Clamp(transform.eulerAngles.y, 25, -25);
        Vector3 moveVector = new Vector3(moveVertical * speed, 0, -moveHorizontal * speed);
        Quaternion deltaRotation = Quaternion.Euler(moveVector * Time.fixedDeltaTime);
        rB.MoveRotation(rB.rotation * deltaRotation);
    }

}
