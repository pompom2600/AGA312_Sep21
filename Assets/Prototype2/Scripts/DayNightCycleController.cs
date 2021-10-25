using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum TimeOfDay {Day, Night }

public class DayNightCycleController : MonoBehaviour
{
    public TimeOfDay timeOfDay;
    public float timer;
    public float timeScale;
    public TMP_Text clock;
    public GameObject sunLight;

    private void Start()
    {
        timer = 12;
    }

    private void Update()
    {
        timer += Time.deltaTime * timeScale;
        clock.text = ("Time: " + timer);
        if (timer >= 24f)
        {
            timer = 0;
        }
    
        if( timer > 7 && timer < 19)
        {
            timeOfDay = TimeOfDay.Day;
        }

        else
        {
            timeOfDay = TimeOfDay.Night;
        }


        Quaternion temp = sunLight.transform.rotation;
        temp.eulerAngles = new Vector3(timer * 15, 0, 0);
        sunLight.transform.rotation = temp;


    }




}
