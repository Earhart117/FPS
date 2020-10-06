using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    public GameObject deathMenuUI;

    public static int _currentScore;

    private void Start()
    {
        PlayerHealth.health = 100;
        Time.timeScale = 1f;
        //deathMenuUI.SetActive(false);
    }
    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }

    }
    public void ExitLevel()
    {
        //compare score to high score
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentScore > highScore)
        {
            //save current score as new high score
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }
        //load main menu
        SceneManager.LoadScene("MainMenu");
    }
    public void IncreaseScore(int scoreIncrease)
    {
        //increase score
        _currentScore += scoreIncrease;
        //update screen display
        _currentScoreTextView.text = "Score: " + _currentScore.ToString();
    }

    public void ResetScore()
    {
        _currentScore = 0;
        _currentScoreTextView.text = "Score: " + _currentScore.ToString();
    }
    
}
