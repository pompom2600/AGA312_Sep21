using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchQuest_Proto6 : MonoBehaviour
{
    public GameObject[] pickup;
    public bool hasPickup;
    public GameObject center;
    public bool nextLevel;
    public GameObject pickupIndicator;
    public GameObject winPanel;
    int count = 0;


    void Start()
    {
        pickupIndicator.SetActive(false);
    }


    void Update()
    {
        pickupIndicator.transform.position = transform.position + new Vector3(0, 1f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Deposit") && hasPickup)
        {
            pickupIndicator.SetActive(false);
            hasPickup = false;

            if (count == pickup.Length)
            {
                //pickupIndicator.SetActive(true);
                center.GetComponent<Renderer>().material.color = Color.green;
                nextLevel = true;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            hasPickup = true;
            pickupIndicator.SetActive(true);
            Destroy(other.gameObject);
            count++;
        }

        

        if (other.CompareTag("Exit") && nextLevel)
        {
            winPanel.SetActive(true);
        }
    }


}
