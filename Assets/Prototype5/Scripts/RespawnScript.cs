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

        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.collider.gameObject, 1f);
        }

        if (collision.collider.CompareTag("Zone"))
        {
            transform.position = spawnPoint.transform.position;
        }

        if (collision.collider.CompareTag("Exit"))
        {
            winPanel.SetActive(true);
        }
    }

 }
