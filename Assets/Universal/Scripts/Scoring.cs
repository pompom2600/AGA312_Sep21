using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : JMC
{
    public int LastRoundScore = 100;
    public int ThisRoundScore = 170;
    public int lives = 5;

    private void Update()
    {
        if (IsGameOver(lives))
         CheckScore();
    }

    void CheckScore()
    {
        Debug.Log("Score difference is" + PercentageChange(LastRoundScore, ThisRoundScore).ToString("F2") + "%");}
}
