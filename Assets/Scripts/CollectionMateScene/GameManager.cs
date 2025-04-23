using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public GameObject gameOverPanel;
    public Text finalScoreText;
    private bool isGameActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void GameOver()
    {
        isGameActive = false;
        Time.timeScale = 0;
        //gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + FindObjectOfType<ScoreManager>().GetScore();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
