/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int playerLife = 1;
    public int playerScore = 0;
    public int highscore = 0;
    
    // For further development
    //public GameObject map;
    public GameObject airship;
    //public GameObject missile;

    // UI Components
    public Text scoreText;
    public GameObject endGameCanvas;

    public bool isGameEnded = false;

	void Awake ()
	{
        // Singleton
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        InitializeGame();
        DontDestroyOnLoad(gameObject);
	}

    private void Start()
    {
        airship = (GameObject)Resources.Load("Player", typeof(GameObject));
    }

    void Update ()
	{
        // Checking Game Over
        if(isGameEnded == true)
        {
            Invoke("GameOver", 1f);
        }

        DisplayScore();
        highscore = PlayerPrefs.GetInt("Highscore");

        // RESET HIGHSCORE
        if(Input.GetKey(KeyCode.X))
        {
            PlayerPrefs.SetInt("Highscore", 0);
        }
	}

    public void DisplayScore()
    {

        scoreText.text = playerScore.ToString();
    }

    public void InitializeGame()
    {
        playerLife = 1;
        playerScore = 0;

        //  Instantiate(airship);
        
        endGameCanvas.SetActive(false);

        isGameEnded = false;
    }

    public void GameOver()
    {
        GameObject missile = GameObject.FindGameObjectWithTag("Missile");
        Destroy(missile);

        endGameCanvas.SetActive(true);
        //enabled = false;

        if(playerScore > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", playerScore);
        }
    }


    public GameObject pausedState;
    public GameObject playingState;
    public GameObject pausedPanel;

    public void Pause()
    {
        pausedState.SetActive(true);
        playingState.SetActive(false);
        pausedPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        pausedState.SetActive(false);
        playingState.SetActive(true);
        pausedPanel.SetActive(false);
        Time.timeScale = 1;
    }
    
    // FOR TESTING
    void ResetHighscore()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            //PlayerPrefs.SetInt("Highscore", 0);
        }
    }
}
