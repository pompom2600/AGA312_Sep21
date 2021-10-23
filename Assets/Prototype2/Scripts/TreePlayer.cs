using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreePlayer : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text waterText;
    public TMP_Text windText;
    public TMP_Text growText;
    public Slider healthSlider;

    [Header("SkyBox")]
    public GameObject raining;
    public GameObject day;
    public GameObject night;
    public GameObject windy;

    [Header("Tree Parts")]
    private Transform treeTrans;
    private Vector3 upgrow;
    public float health = 50f;

    [Header("Bools")]
    public bool isRaining;
    public bool isDay;
    public bool isNight;
    public bool isWindy;


    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        raining.SetActive(isRaining);
        day.SetActive(isDay);
        night.SetActive(isNight);
        windy.SetActive(isWindy);
    }

    void Update()
    {
        healthSlider.value = health;
        health = Mathf.Clamp(health, 0f, 100f);
        //transform.rotation = Mathf.Clamp(-75, 0);

        WaterAbsorbtion();
        SunAbsorbtion();
        WindAbsorbtion();
    }


    public void GrowTree()
    {
        if (health >= 25)
        {
            health = health - 25;
            upgrow = new Vector3(0.5f, 2, 0.5f);
            transform.localScale += upgrow;
        }

    }

    void WaterAbsorbtion()
    {
        if (isRaining && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            health = health + 5;
        }
    }
    void SunAbsorbtion()
    {
        if (isDay && Input.GetKeyDown(KeyCode.Mouse0))
        {
            health++;
        }
    }
    void WindAbsorbtion()
    {
        if (isWindy)
        {
           transform.Rotate(-.05f, 0, 0 * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space))
            {
                transform.Rotate(.1f, 0, 0 * Time.deltaTime);
                health = health--;
            }
        }
    }

}
