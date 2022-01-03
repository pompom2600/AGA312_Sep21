using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    
    public TMP_Text textDisplay;
    public GameObject losePanel;
    public int secondsLeft = 60;
    public int minutesLeft = 2;
    public bool countDown = false;

    void Start()
    {
        textDisplay.text = "Timer: " + minutesLeft + ":" + secondsLeft;
        countDown = false;
    }


    void Update()
    {
        if (countDown == false && secondsLeft >= 0)
        {
            StartCoroutine(Timertake());
        }

    }



    IEnumerator Timertake()
    {
        countDown = true;
        Debug.Log("TimerTake active");
        yield return new WaitForSeconds(1);

        secondsLeft --;
        if (secondsLeft == 0 && minutesLeft == 0)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
            textDisplay.text = "Timer: Lose";
        }
        else if (secondsLeft <= 0)
        {
            minutesLeft--;
            secondsLeft = 60;
        }

        if (secondsLeft < 10)
        {
            textDisplay.text = "Timer: " + minutesLeft + ":0" + secondsLeft;
            
        }

        else
        {
            textDisplay.text = "Timer: " + minutesLeft + ":" + secondsLeft;
        }
        countDown = false;

    }


}
