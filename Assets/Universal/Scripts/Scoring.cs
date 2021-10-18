using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : JMC
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

    public List<GameObject> collectables;


    float timer = 0;
    bool isTiming = true;

    private void Start()
    {
        winPanel.SetActive(false);
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
        }
        else
        {
            bestTimeText.text = "Best Time: Not Yet Set ";
            bestTime = 1000000;
        }

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
    }

    void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Collect(other.gameObject);
    }

    public void Collect(GameObject _go)
    {
        _go.SetActive(false);
        collectables.Remove(_go);
        if(collectables.Count == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isTiming = false;
        currentTimeWinText.text = "Your Time: " + currentTime.ToString("F2");
        if (currentTime <= bestTime)
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
        PlayerPrefs.Save();
        winPanel.SetActive(true);
    }

    void CheckScore()
    {
        Debug.Log("Score difference is" + PercentageChange(lastRoundScore, thisRoundScore).ToString("F2") + "%");}
}
