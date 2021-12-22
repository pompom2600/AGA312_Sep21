using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject winPanel;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Zone"))
        {
            transform.position = spawnPoint.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            winPanel.SetActive(true);
        }
    }

 }
