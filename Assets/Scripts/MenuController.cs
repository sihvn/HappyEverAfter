using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public CanvasGroup c;
    public AudioSource menuSelection;
    AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioClip = menuSelection.clip;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartNewGame()
    {
        menuSelection.PlayOneShot(audioClip);
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        for (float alpha = 1f; alpha >= -0.05f; alpha -= 0.05f)
        {
            c.alpha = alpha;
            yield return new WaitForSecondsRealtime(0.1f);
        }

        // once done, go to next scene
        SceneManager.LoadSceneAsync("OutsideCastle", LoadSceneMode.Single);
    }

}
