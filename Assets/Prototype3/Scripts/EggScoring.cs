using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EggScoring : JMC
{

    public int lastRoundScore = 100;
    public int thisRoundScore = 170;
    public int lives = 5;

    [Header("Score Based")]
    public int highestScore;
    public int currentScore;
    public TMP_Text currentScoreText;
    public TMP_Text highScoreText;

    [Header("Time Based")]
    public float bestTime;
    public float currentTime;
    public TMP_Text bestTimeText;
    public TMP_Text currentTimeText;

    [Header("Panel")]
    public GameObject winPanel;
    public TMP_Text bestTimeWinText;
    public TMP_Text currentTimeWinText;
    public TMP_Text winMessageText;

    public GameObject topTimesPanel;
    public List<float> topTimes;
    public List<TMP_Text> topTimesText;

    [Header("Other")]
    public GameObject platform;
    [SerializeField] TiltControl tiltControl;


    float timer = 0;
    bool isTiming = true;

    private void Start()
    {

        platform.GetComponent<Transform>();
        winPanel.SetActive(false);
        topTimesPanel.SetActive(false);
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
        }
        else
        {
            bestTimeText.text = "Best Time: Not Yet Set ";
            bestTime = 0.1f;
        }

        LoadTopTimes();
    }

    private void Update()
    {
        if (isTiming)
            currentTime += Time.deltaTime;

        currentTimeText.text = "Current Time: " + currentTime.ToString("F2");
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            DeletePrefs();
        }

        if (tiltControl.egg.transform.position.y < -10)
        {
            GameOver();
        }
    }

    void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    void GameOver()
    {
        isTiming = false;
        currentTimeWinText.text = "Your Time: " + currentTime.ToString("F2");
        if (currentTime >= bestTime)
        {
            bestTime = currentTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            winMessageText.text = "Congratulations!!\n You've Got a New Best Time!!!";
        }
        else
        {
            winMessageText.text = "Bad Luck \n Try Again Buddy";
        }
        bestTimeWinText.text = "Best Time: " + bestTime.ToString("F2");
        SetTopTimes();
        PlayerPrefs.Save();
        winPanel.SetActive(true);
        topTimesPanel.SetActive(true);
    }

    void LoadTopTimes()
    {
        for (int i = 0; i < topTimesText.Count; i++)
        {
            if (PlayerPrefs.GetFloat("TopTime" + i.ToString())!= 0)
            {
                topTimes.Add(PlayerPrefs.GetFloat("TopTime" + i.ToString()));
            }
            else
            {
                topTimes.Add(0.1f);
            }
        }
        DisplayTopTimes();
    }

    void SetTopTimes()
    {
        topTimes.Add(currentTime);
        topTimes.Sort();
        if (topTimes.Count >= 10)
        {
            topTimes.RemoveAt(topTimes.Count - 1); //Last one is removed
        }

        for (int i = 0; i < topTimesText.Count; i++)
        PlayerPrefs.SetFloat("TopTime" + i.ToString(), topTimes[i]);
        
        Debug.Log("Setting Top Times");
        DisplayTopTimes();
    }


    void DisplayTopTimes()
    {
        for (int i = 0; i < topTimesText.Count; i++)
        {
            if (topTimes[i] != 99999)
            {
                topTimesText[i].text = (i + 1).ToString() + ": " + topTimes[i].ToString("F3");
            }
            else
                topTimesText[i].text = "No Time Set";
        }
        Debug.Log("Display Top Times");
    }


    void CheckScore()
    {
        Debug.Log("Score difference is" + PercentageChange(lastRoundScore, thisRoundScore).ToString("F2") + "%");
    }
}
