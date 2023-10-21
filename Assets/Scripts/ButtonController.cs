using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseScene;
    public AudioMixer mixer;
    AudioClip audioClip;
    public AudioSource buttonSelection;
    // Start is called before the first frame update
    void Start()
    {
        audioClip = buttonSelection.clip;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void pauseButton()
    {
        buttonSelection.PlayOneShot(audioClip);

        Time.timeScale = isPaused ? 1.0f : 0.0f;
        isPaused = !isPaused;
        if (isPaused)
        {
            mixer.SetFloat("Master", -80f);
            pauseScene.SetActive(true);
        }
        else
        {
            mixer.SetFloat("Master", 0f);
            pauseScene.SetActive(false);
        }
    }
    public void restartButton()
    {
        buttonSelection.PlayOneShot(audioClip);
        GameManager.Instance.GameRestart();
    }
}
