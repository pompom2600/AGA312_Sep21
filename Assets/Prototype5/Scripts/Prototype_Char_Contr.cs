using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prototype_Char_Contr : MonoBehaviour
{

    [Header("UI")]
    public GameObject winPanel;
    //public float timer = 30;
    int count = 0;


    [Header("Player")]
    private Rigidbody playerRb;

    [Header("Indicators")]
    public GameObject center;

    [Header("Other")]
    public GameObject[] pickup;
    public bool nextLevel;


    public Color originalColor;
    public Color depositColor;

    void Start()
    {

    }

    void Update()
    {

       
        /* if (timerBool == true)
            {
                print("bool on");
                timer = timer - Time.deltaTime;
                timerText.text = "Timer: " + timer.ToString("F0");
        }
        if (timer <= 0)
            {
                //TimerPanel.SetActive(false);
                timerBool = false;
            }*/
    }


    private void FixedUpdate()
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Pickup"))
        {
            count++;
            Destroy(other.gameObject);


            if (count == pickup.Length)
            {
                //pickupIndicator.SetActive(true);
                center.GetComponent<Renderer>().material.color = Color.green;
                nextLevel = true;
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

        if (collision.collider.CompareTag("Exit"))
        {
            winPanel.SetActive(true);
        }
    }

}
