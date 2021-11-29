using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
    public GameObject gamePanel;

    public bool gameBool;


    [Header("Player")]
    public GameObject player;
    public Transform originalPos;
    public TMP_Text movesText;
    public int moves = 50;


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
        originalPos = player.GetComponent<Transform>();
        GenerateOperators();

    }

    void Update()
    {
        movesText.text = "Moves Left: " + moves;
        if (moves <= 0)
        {
            losePanel.SetActive(true);
            gamePanel.SetActive(false);
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
    }

    void GenerateAddition()
    {
        GenerateNumbers();
        operatorText.text = "+";
        correctAnswer = numberOne + numberTwo;
        Debug.Log(numberOne + " + " + numberTwo + " = " + correctAnswer);
    }

    void GenerateSubtraction()
    {
        GenerateNumbers();
        operatorText.text = "-";
        correctAnswer = numberOne - numberTwo;
        Debug.Log(numberOne + " - " + numberTwo + " = " + correctAnswer);
    }

    void GenerateDivision()
    {
        GenerateNumbers();
        operatorText.text = "/";
        correctAnswer = numberOne / numberTwo;
        correctAnswer = Mathf.RoundToInt(correctAnswer);
        Debug.Log(numberOne + " / " + numberTwo + " = " + correctAnswer);
    }

    /// Gets a random number based on our difficulty
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

    public void NumberOneInput(string _input)
    {
        numberOne = int.Parse(_input);
    }

    public void NumberTwoInput(string _input)
    {
        numberTwo = int.Parse(_input);
    }

    public void UpMove()
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

        if (answer <= 0)
        {
            answer = 0;
        }
        GenerateOperators();
        transform.Translate(new Vector3(0, 5, answer));

        moves--;

        //clear inputfield text 
        //inputField1.text
    }

    public void DownMove()
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

        if (answer <= 0)
        {
            answer = 0;
        }
        answerText.text = answer.ToString();

        GenerateOperators();
        transform.Translate(new Vector3(0, 5, -answer));

        moves--;
    }

    public void LeftMove()
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

        if (answer <= 0)
        {
            answer = 0;
        }
        answerText.text = answer.ToString();

        GenerateOperators();
        transform.Translate(new Vector3(-answer, 5, 0));

        moves--;
    }

    public void RightMove()
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

        if (answer <= 0)
            answer = 0;

        answerText.text = answer.ToString();

        GenerateOperators();

        transform.Translate(new Vector3(answer, 5, 0));

        moves--;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zone"))
        {
            Debug.Log("potato");
            transform.position = originalPos.position;
        }

        if (collision.gameObject.CompareTag("Exit"))
        {
            winPanel.SetActive(true);
            gamePanel.SetActive(false);
        }
    }
}

