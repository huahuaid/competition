using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    //public Text scoreText;
    public TextMeshPro scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreDisplay();
    }

    public int GetScore() => score;

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }
}
