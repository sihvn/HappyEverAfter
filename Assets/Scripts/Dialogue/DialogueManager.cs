using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkFile;
    public GameObject textBox;
    public GameObject customButton;
    public GameObject optionPanel;
    public GameObject dialoguePanel;

    static Story story;
    public TextMeshProUGUI message;
    public TextMeshProUGUI choiceMessage;
    static Choice choiceSelected;
    public Animator princessAnim;
    public Animator playerAnim;
    AudioClip playerAudioClip;
    public AudioSource playerDeath;
    AudioClip princessAudioClip;
    public AudioSource princessAttack;



    // Start is called before the first frame update
    void Start()
    {
        playerAudioClip = playerDeath.clip;
        princessAudioClip = princessAttack.clip;
        story = new Story(inkFile.text);
        choiceSelected = null;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            dialoguePanel.SetActive(true);

            if (story.canContinue)
            {

                //Debug.Log("HELLU");
                AdvanceDialogue();

                if (story.currentChoices.Count != 0)
                {
                    //Debug.Log("HELL11U");
                    StartCoroutine(ShowChoices());
                }
            }
            else
            {
                FinishDialogue();
            }
        }
    }


    private void FinishDialogue()
    {
        dialoguePanel.SetActive(false);
        optionPanel.SetActive(false);
        princessAttack.PlayOneShot(princessAudioClip);
        princessAnim.SetTrigger("kill");
        playerDeath.PlayOneShot(playerAudioClip);
        playerAnim.Play("player_die");
        StartCoroutine(BackToMenu());
    }
    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }

    void AdvanceDialogue()
    {
        string currentSentence = story.Continue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    // Type out the sentence letter by letter and make character idle if they were talking
    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return null;
        }

    }

    // Create then show the choices on the screen until one got selected
    IEnumerator ShowChoices()
    {
        Debug.Log("There are choices need to be made here!");
        List<Choice> _choices = story.currentChoices;
        Debug.Log(_choices[0].text);
        choiceMessage.text = _choices[0].text;

        // temp.AddComponent<Selectable>();
        // temp.GetComponent<Selectable>().element = _choices[i];
        // temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Selectable>().Decide(); });


        optionPanel.SetActive(true);

        yield return new WaitUntil(() => { return choiceSelected != null; });


    }

    // Tells the story which branch to go to
    public void SetDecision()
    {
        story.ChooseChoiceIndex(0);
        AdvanceFromDecision();
    }

    // After a choice was made, turn off the panel and advance from that choice
    void AdvanceFromDecision()
    {

        optionPanel.SetActive(false);
        // for (int i = 0; i < optionPanel.transform.childCount; i++)
        // {
        //     Destroy(optionPanel.transform.GetChild(i).gameObject);
        // }
        choiceSelected = null; // Forgot to reset the choiceSelected. Otherwise, it would select an option without player intervention.
        AdvanceDialogue();
    }




}