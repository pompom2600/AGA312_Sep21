using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMC : MonoBehaviour
{

    /// <summary>
    /// Use this to check if we are at game over
    /// </summary>
    /// <param name="_lives">The players current lives</param>
    /// <returns>True if players lives are 0</returns>
    public bool IsGameOver(int _lives)
    {
        return _lives == 0;}

    /// <summary>
    /// Works out the change in percentages between two scores
    /// </summary>
    /// <param name="_score1">The original score</param>
    /// <param name="_score2">The new score</param>
    /// <returns>Percentage change between _score1 and _score2</returns>
    public float PercentageChange(float _score1, float _score2)
    {
        float change = _score2 - _score1;
        return change / _score1 * 100;}


    
}
