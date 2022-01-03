using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [Header("Win Con")]
    public GameObject winPanel;

    [Header("SpawnPoints")]
    public GameObject spawnPointA;
    public GameObject spawnPointB;
    public GameObject spawnPointC;
    public GameObject spawnPointD;
    public GameObject spawnPointE;
    
      
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            winPanel.SetActive(true);
        }
        if (other.CompareTag("TP1"))
        {
            Debug.Log("TP1");
            transform.position = spawnPointA.transform.position;
        }

        if (other.CompareTag("TP2"))
        {
            Debug.Log("TP2");
            transform.position = spawnPointB.transform.position;
        }

        if (other.CompareTag("TP3"))
        {
            Debug.Log("TP3");
            transform.position = spawnPointC.transform.position;
        }

        if (other.CompareTag("TP4"))
        {
            Debug.Log("TP4");
            transform.position = spawnPointD.transform.position;
        }

        if (other.CompareTag("TP5"))
        {
            Debug.Log("TP5");
            transform.position = spawnPointE.transform.position;
        }

    }

}
