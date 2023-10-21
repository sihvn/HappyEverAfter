using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // events
    public UnityEvent gameStart;
    public UnityEvent gameRestart;
    public UnityEvent gameOver;
    AudioClip audioClip;
    public AudioSource background;
    bool played = false;
    // public UnityEvent changeUI;
    // private int score = 0;

    // use it as per normal

    void Start()
    {
        if (!played)
        {
            audioClip = background.clip;
            background.PlayOneShot(audioClip);
            played = true;
        }

        gameStart.Invoke();
        Time.timeScale = 1.0f;
        // subscribe to scene manager scene change
        SceneManager.activeSceneChanged += SceneSetup;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SceneSetup(Scene current, Scene next)
    {
        gameStart.Invoke();
        // SetScore(score);
    }

    public void GameRestart()
    {
        gameRestart.Invoke();
        Time.timeScale = 1.0f;

    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOver.Invoke();
    }
    // public void UpdateUI()
    // {
    //     changeUI.Invoke();
    // }
}