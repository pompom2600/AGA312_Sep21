using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //UI
    public TMP_Text pickupText;
    public TMP_Text winText;
    public int count = 0;

    //Player
    private Rigidbody playerRb;
    public float speed = 5f;
    private Vector3 SpawnPoint;
    private GameObject focalPoint;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;


    public float tweenTime = 1f;

    //Powerup
    public bool hasPowerup;
    private float powerupStrength = 15f;

    //Indicators
    public GameObject powerupIndicator;
    public GameObject pickupIndicator;

    //Pickup
    public bool hasPickup;
    public GameObject sphere;
    public Color originalColor;
    public Color depositColor;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        SpawnPoint = transform.position;
    }

    void Update()
    {
        Jumping();
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -.5f, 0);
        pickupIndicator.transform.position = transform.position + new Vector3(0, 2.5f, 0);
        if (transform.position.y < -10)
        {
            transform.position = SpawnPoint;
        }
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Deposit") && hasPickup) {
            sphere.GetComponent<Renderer>().material.color = depositColor;
            count++;
            ScoreText(count);
            pickupIndicator.gameObject.SetActive(false);
            hasPickup = false;
            sphere.transform.localScale += Vector3.one;
            if (count >= 5)
            {
                winText.gameObject.SetActive(true);
                winText.color = RandomColor();
            }
        }

        if (other.CompareTag("Pickup") && !hasPickup) {
            hasPickup = true;
            Destroy(other.gameObject);
            pickupIndicator.gameObject.SetActive(true);
        }

        if (other.CompareTag("Powerup")) {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountDownRoutine());
        }

        IEnumerator PowerupCountDownRoutine()
        {
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Deposit"))
        {
            sphere.GetComponent<Renderer>().material.color = originalColor;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    public void ScoreText(int _score)
    {
        pickupText.text = "Stars Deposited: " + _score + " Out of 5";
    }

    public Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public void Jumping()
    {
        if (playerRb.velocity.y < 1)
            playerRb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        else if (playerRb.velocity.y > 1 && !Input.GetButtonDown("Jump"))
            playerRb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

    }
}


