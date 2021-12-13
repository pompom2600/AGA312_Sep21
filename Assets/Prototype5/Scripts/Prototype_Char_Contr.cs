using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prototype_Char_Contr : MonoBehaviour
{

    [Header("UI")]
    public GameObject winPanel;
    public GameObject TimerPanel;
    public TMP_Text timerText;
    public int timer = 30;
    int count = 0;


    [Header("Player")]
    private Rigidbody playerRb;
    private Vector3 spawnPoint;

    [Header("Indicators")]
    public GameObject pickupIndicator;
    public GameObject center;

    [Header("Other")]
    public GameObject[] pickup;
    public GameObject pressurePlate;
    public GameObject lockedDoor;
    public GameObject pressureDoor;
    public bool nextLevel;
    public bool timerBool;


    public Color originalColor;
    public Color depositColor;

    void Start()
    {
        spawnPoint = transform.position;
        timerText.text = " " + timer;
    }

    void Update()
    {
        pickupIndicator.transform.position = transform.position + new Vector3(0, 1f, 0);

        if (timerBool == true)
        {
            print("bool on");
            timer--;
        }
    }


    private void FixedUpdate()
    {
        if (timer <= 0)
        {
            TimerPanel.SetActive(false);
            timerBool = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Pickup"))
        {
            count++;
            Destroy(other.gameObject);
            pickupIndicator.SetActive(true);

            if (count == pickup.Length)
            {
                center.GetComponent<Renderer>().material.color = Color.green;
                nextLevel = true;
                Destroy(lockedDoor);
            }
        }


        if (other.CompareTag("Exit") && nextLevel)
        {
            winPanel.SetActive(true);
        }

        


        /*if (other.CompareTag("Deposit") && hasPickup)
        {
            sphere.GetComponent<Renderer>().material.color = depositColor;
            count++;
            ScoreText(count);
            pickupIndicator.gameObject.SetActive(false);
            hasPickup = false;
            sphere.transform.localScale += Vector3.one;
            if (count >= 5)
            {
                winPanel.SetActive(true);
                winText.color = RandomColor();
                Time.timeScale = 0;
            }
        }*/

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.collider.gameObject, 1f);
        }

        if (collision.collider.CompareTag("Zone"))
        {
            transform.position = spawnPoint;
        }

        if (collision.collider.CompareTag("Plate"))
        {
            pressurePlate.GetComponent<Renderer>().material.color = Color.black;
            pressureDoor.SetActive(false);
            TimerPanel.SetActive(true);
            timerBool = true;
        }
    }

}
