using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour
{
    private bool isPaused = false;
    public Sprite pauseIcon;
    public Sprite playIcon;
    public AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Time.timeScale = isPaused ? 1.0f : 0.0f;
        isPaused = !isPaused;
        if (isPaused)
        {
            mixer.SetFloat("MasterVolume", -80f);

        }
        else
        {
            mixer.SetFloat("MasterVolume", 0f);
        }
    }
}
