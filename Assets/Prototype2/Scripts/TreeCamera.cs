using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCamera : MonoBehaviour
{
    public GameObject tree;
    private Vector3 Offset;

    void Start()
    {
        Offset = transform.position - tree.transform.position;
    }

 
    void Update()
    {
        transform.position = tree.transform.position + Offset;
    }
}
