using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MathtasticMath : MonoBehaviour
{

    [Header("UI")]
    public TMP_Text answerText;
    public TMP_Text operatorText;
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public GameObject winPanel;
    public GameObject losePanel;

    [Header("Player")]
    public GameObject player;
    public TMP_Text livesText;
    public int lives = 3;


    //[Header("Enums")]
    public enum Difficulty { EASY, MEDIUM, HARD }
    public Difficulty difficulty;

    public enum Operators { Plus, Minus, Divide, Times }
    public Operators operators;

    [Header("Numbers")]
    private int numberOne;
    private int numberTwo;
    public int correctAnswer;

    public List<int> dummyAnswers;

    public void Start()
    {
        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            MovePlayer();
        }
    }

    void GenerateNumbers()
    {
        numberOne = GetRandomNumbers();
        numberTwo = GetRandomNumbers();
    }

    void GenerateOperators()
    {
        int rnd = Random.Range(0, 3);
        operators = (Operators)rnd;

        if (operators == Operators.Plus)
            operatorText.text = "+";
        if (operators == Operators.Minus)
            operatorText.text = "-";
        if (operators == Operators.Divide)
            operatorText.text = "/";
        if (operators == Operators.Times)
            operatorText.text = "x";
    }

    void GenerateMultiplication()
    {
        GenerateNumbers();
        operatorText.text = "x";
        correctAnswer = numberOne * numberTwo;
        Debug.Log(numberOne + " x " + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
    }

    void GenerateAddition()
    {
        GenerateNumbers();
        operatorText.text = "+";
        correctAnswer = numberOne + numberTwo;
        Debug.Log(numberOne + " + " + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
    }

    void GenerateSubtraction()
    {
        GenerateNumbers();
        operatorText.text = "-";
        correctAnswer = numberOne - numberTwo;
        Debug.Log(numberOne + " - " + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
    }

    void GenerateDivision()
    {
        GenerateNumbers();
        operatorText.text = "/";
        correctAnswer = numberOne / numberTwo;
        correctAnswer = Mathf.RoundToInt(correctAnswer);
        Debug.Log(numberOne + " / " + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
    }

    /// <summary>
    /// Gets a random number based on our difficulty
    /// </summary>
    /// <returns>A random number</returns>
    int GetRandomNumbers()
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                return (Random.Range(1, 10));
            case Difficulty.MEDIUM:
                return (Random.Range(1, 20));
            case Difficulty.HARD:
                return (Random.Range(1, 100));
            default:
                return (Random.Range(1, 10));
        }
    }

    /// <summary>
    /// This will generate a set of dummy answers
    /// </summary>
    private void GenerateDummyAnswers()
    {
        for (int i = 0; i < dummyAnswers.Count; i++)
        {
            int dummy;
            do
            {
                dummy = Random.Range(correctAnswer - 10, correctAnswer + 10);
            }
            while (dummy == correctAnswer || dummyAnswers.Contains(dummy));
            dummyAnswers[i] = dummy;
            Debug.Log("Dummy answer: " + dummyAnswers[i]);
        }
    }
    public void NumberOneInput(string _input)
    {
        numberOne = int.Parse(_input);
    }

    public void NumberTwoInput(string _input)
    {
        numberTwo = int.Parse(_input);
    }

    public void MovePlayer()
    {
        int answer = 0;
        if (operators == Operators.Plus)
            answer = numberOne + numberTwo;
        if (operators == Operators.Minus)
            answer = numberOne - numberTwo;
        if (operators == Operators.Divide)
            answer = numberOne / numberTwo;
        if (operators == Operators.Times)
            answer = numberOne * numberTwo;


        answerText.text = answer.ToString();
        //player.transform.DOMoveX(10, .5f);
        GenerateOperators();
        transform.Translate(new Vector3(answer, 0, 0));
    }

    private void OnTriggerTrigger(Collider collision)
    {
        if (collision.CompareTag("Zone"))
        {
            lives--;
            //resart position

            if(lives <= 0)
                losePanel.SetActive(true);
        }

        if (collision.CompareTag("Exit"))
            winPanel.SetActive(true);
    }
}
