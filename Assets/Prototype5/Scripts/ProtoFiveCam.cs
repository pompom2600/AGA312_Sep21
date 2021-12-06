using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoFiveCam : MonoBehaviour
{
    public float rotationSpeed = 50;
    public GameObject Player;
    private Vector3 Offset;

    void Start()
    {
        Offset = transform.position - Player.transform.position;
    }

    void Update()
    {
        transform.position = Player.transform.position + Offset;
    }
}
