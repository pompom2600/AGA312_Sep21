using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PivotPlayerController : MonoBehaviour
{
    [Header("UI")]
    public GameObject LosePanel;
    public TMP_Text winText;


    [Header("Player")]
    private Rigidbody playerRb;
    private Transform playerTrans;
    private Quaternion playerQuater;
    public float speed = 1f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header ("Other")]
    public float tweenTime = 1f;
    public GameObject ball;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        LosePanel.SetActive(false);
        playerQuater = GetComponent<Quaternion>();
        playerTrans = GetComponent<Transform>();

    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float sideInput = Input.GetAxis("Horizontal");
        playerTrans.rotation = new Quaternion(sideInput, forwardInput, forwardInput + sideInput, 0 );
        //playerQuater
       // playerRb.AddForce(focalPoint.transform.forward * forwardInput);
        if (ball.transform.position.y < -5)
        {
            LosePanel.SetActive(true);
        }
    }

    public Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

  
}


