using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TreePlayer : MonoBehaviour
{
    [Header("UI")]
    public GameObject rainInfo;
    public GameObject windInfo;
    public GameObject growInfo;
    public Slider healthSlider;

    public GameObject winPanel;
    public GameObject losePanel;

    [Header("SkyBox")]
    public GameObject raining;
    public GameObject windy;
    public GameObject rainParticals;
    public GameObject windParticals;

    [Header("Tree Parts")]
    private Quaternion origPos;
    private Vector3 winSize;
    private Vector3 local;
    private Vector3 upgrow;
    public float health = 50f;

    [Header("Bools")]
    public bool isRaining;
    public bool isWindy;

    [Header("Timers")]
    public float windTimer = 30;
    public float waterTimer = 20;
    
    DayNightCycleController DayNight;


    void Start()
    {
        winSize = new Vector3(7,19,7);
        Time.timeScale = 0;

        origPos = transform.rotation;
        DayNight = FindObjectOfType<DayNightCycleController>();
        InvokeRepeating("Wind", 1, 1);
        InvokeRepeating("Rain", 1, 1);
    }

    private void FixedUpdate()
    {
        raining.SetActive(isRaining);
        rainInfo.SetActive(isRaining);
        rainParticals.SetActive(isRaining); 
        growInfo.SetActive(IsDay());
        windy.SetActive(isWindy);
        windInfo.SetActive(isWindy);
        windParticals.SetActive(isWindy);

    }

    void Update()
    {
        healthSlider.value = health;
        health = Mathf.Clamp(health, 0f, 100f);
        local = transform.localScale;

        if (isWindy)
        {
            WindAbsorbtion();
        }

        if (isRaining)
        {
            WaterAbsorbtion();
        }
        if (IsDay())
        {
            SunAbsorbtion();
        }

        float tippingThreshold = 60;
        float xRotation = transform.rotation.eulerAngles.x;
        while (xRotation > 180) xRotation -= 360;

        if (Mathf.Abs(xRotation) > tippingThreshold)
        {
            LoseGame();
        }

        if (health <= 0)
        {
            Time.timeScale = 0;
            LoseGame();
        }

        if (local == winSize)
            {
            WinGame();
            }
    }

    public void LoseGame()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void GrowTree()
    {
        if (health >= 25)
        {
            health -= 24;
            upgrow = new Vector3(0.5f, 2, 0.5f);
            transform.localScale += upgrow;
        }

    }

    void WaterAbsorbtion()
    {
        if (waterTimer >= 0)
        {
            waterTimer = waterTimer - 0.01f;

            if (Input.GetKeyDown(KeyCode.LeftAlt))
                health += 5;
        }

        if (waterTimer <= 0)
        {
            isRaining = false;
            waterTimer = 20;
        }
    }
    void SunAbsorbtion()
    {
        if (IsDay())
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                health++;
            }
        }

    }
    void WindAbsorbtion()
    {
        if (windTimer >= 0)
        {
           windTimer = windTimer - 0.01f;
           transform.Rotate(-.05f, 0, 0 * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space))
            { 
                transform.Rotate(.1f, 0, 0 * Time.deltaTime);
                health = health - .05f;
            }
        }

        if (windTimer <= 0)
        {
            isWindy = false;
            windTimer = 30;
            transform.rotation = origPos;
        }
    }

    void Rain()
    {
        if (isRaining)
            return;

        int rnd = Random.Range(0, 10);
        if (rnd == 5)
        {
            isRaining = true;
        }
    }

    void Wind()
    {
        if (isWindy)
            return;

        int rnd = Random.Range(0, 10);
        if (rnd == 5) 
        {
            isWindy = true;
        }
    }

    bool IsDay()
    {
        return DayNight.timeOfDay == TimeOfDay.Day;
    }

}
