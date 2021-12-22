using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchQuest_Proto6 : MonoBehaviour
{
    public GameObject pickup;
    public bool hasPickup;
    public GameObject center;
    public bool nextLevel;
    public GameObject pickupIndicator;
    public GameObject winPanel;


    void Start()
    {
        pickupIndicator.SetActive(false);
    }


    void Update()
    {
        pickupIndicator.transform.position = transform.position + new Vector3(0, 1f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            hasPickup = true;
            pickupIndicator.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Deposit") && hasPickup)
        {
            center.GetComponent<Renderer>().material.color = Color.green;
            nextLevel = true;
            pickupIndicator.SetActive(false);
        }

        if (other.CompareTag("Exit") && nextLevel)
        {
            winPanel.SetActive(true);
        }
    }


}
