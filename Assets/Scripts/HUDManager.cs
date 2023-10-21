using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    // private Vector3[] scoreTextPosition = {
    //     new Vector3(-747, 473, 0),
    //     new Vector3(0, 0, 0)
    //     };
    // private Vector3[] restartButtonPosition = {
    //     new Vector3(844, 455, 0),
    //     new Vector3(0, -150, 0)
    // };

    // public GameObject scoreText;
    // public GameObject scoreText2;

    // public Transform restartButton;


    public GameObject inGameScene;
    public GameObject gameOverScene;
    // public GameObject Enemy1;
    // public GameObject Enemy2;

    // public GameObject highscoreText;
    void Start()
    {
        GameManager.Instance.gameStart.AddListener(GameStart);
        GameManager.Instance.gameOver.AddListener(GameOver);
        GameManager.Instance.gameRestart.AddListener(GameStart);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void Awake()
    {

    }


    public void GameStart()
    {
        // hide gameover panel
        gameOverScene.SetActive(false);
        inGameScene.SetActive(true);
        // Enemy1.SetActive(true);
        //Enemy2.SetActive(true);
    }

    public void GameOver()
    {
        gameOverScene.SetActive(true);
        inGameScene.SetActive(false);
    }
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
}
