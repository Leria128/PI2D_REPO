using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NPCDialogue : MonoBehaviour
{
    bool isPlayerInRange;
    bool didDialogueStart;
    int lineIndex;

    [SerializeField] float typingSpeed = 0.05f;

    [Header("UI")]
    [SerializeField] GameObject dialogueMark;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TMP_Text dialogueText;

    [Header("Dialogue")]
    [SerializeField, TextArea(4, 6)] string[] dialogueLines;

    [Header("NPC Swap")]
    [SerializeField] GameObject npcToSwap;
    float switchDelay = 4f;
    bool isSwitching = false;

    [Header("Scene Transition")]
    [SerializeField] int sceneToLoad;
    [SerializeField] bool canLoadScene;

    public bool CanInteract => isPlayerInRange;

    public void Interact()
    {
        if (isSwitching)
        {
            return;
        }

        if (!didDialogueStart)
        {
            StartDialogue();
        }
        else if (dialogueText.text == dialogueLines[lineIndex])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];
        }
    }

    void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;

        StartCoroutine(ShowLine());
    }

    void NextLine()
    {
        lineIndex++;

        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;

            if (npcToSwap != null)
            {
                dialogueMark.SetActive(false);
                isSwitching = true;
                StartCoroutine(SwitchWithDelay());
            }
            if (canLoadScene == true)
            {
                dialogueMark.SetActive(false);
                isSwitching = true;
                StartCoroutine(SceneTransition());
            }
        }
    }
    IEnumerator SwitchWithDelay()
    {

        yield return new WaitForSecondsRealtime(switchDelay);
        npcToSwap.SetActive(true);
        gameObject.SetActive(false);
       
    }

    IEnumerator SceneTransition()
    {
        yield return StartCoroutine(FadeManager.Instance.FadeOut());
      
        SceneManager.LoadScene(sceneToLoad);

    }


    IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
    void start()
    {

        npcToSwap.SetActive(false);
    }
}
