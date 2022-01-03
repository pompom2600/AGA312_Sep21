using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject winPanel;

    public GameObject pressureDoor1;
    public GameObject pressureDoor2;
    public GameObject pressureDoor3;
    public GameObject pressureDoor4;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            winPanel.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {



        if (collision.collider.CompareTag("Plate"))
        {
            pressureDoor1.SetActive(false);
        }

        if (collision.collider.CompareTag("Plate2"))
        {
            pressureDoor2.SetActive(false);
        }

        if (collision.collider.CompareTag("Plate3"))
        {
            pressureDoor3.SetActive(false);
        }
        if (collision.collider.CompareTag("Plate4"))
        {
            pressureDoor4.SetActive(false);
        }
    }
}
