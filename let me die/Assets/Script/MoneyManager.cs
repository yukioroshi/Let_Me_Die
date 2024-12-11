using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    
    public static int score = 0;

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        UpdateScoreUI();
    }

    private void FixedUpdate()
    {
        UpdateScoreUI();
    }


    public static void AddScore(int value)
    {
        score += value;
        //Debug.Log("Score: " + score);
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Money: " + score;
    }

}
