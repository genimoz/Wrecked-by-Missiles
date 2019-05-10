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

public class GameOverMenu : MonoBehaviour
{
    public Text recentScoreText;
    public Text HighScoreText;
    
    private void Update()
    {
        recentScoreText.text = GameManager.instance.playerScore.ToString();
        HighScoreText.text = GameManager.instance.highscore.ToString();
    }

    public void Retry()
    {
        GameObject manager = GameObject.Find("GameManager");
        Destroy(manager);

        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
