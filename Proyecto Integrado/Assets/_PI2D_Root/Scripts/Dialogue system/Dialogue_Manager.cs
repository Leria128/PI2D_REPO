using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem_V
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }
        [SerializeField] private Dialogue_UI dialogueUI;
        private Queue<Dialogue_Turn> dialogueTurnsQueue;

        public bool IsDialogInProgress { get; private set; } = false;

        private void Awake()
        {
            Instance = this;
            dialogueUI.HideDialogBox();
        }

        public void StartDialogue(Dialogue_Round dialogue)
        {
            if (IsDialogInProgress) 
            {
                Debug.LogWarning($"Dialogue already in progress");
                return;
            }

            IsDialogInProgress = true;
            dialogueTurnsQueue = new Queue<Dialogue_Turn>(dialogue.Dialogue_Turns);
            StartCoroutine(DialogueCoroutine());
        }

        private IEnumerator DialogueCoroutine()
        {
            dialogueUI.ShowDialogBox();

            while (dialogueTurnsQueue.Count > 0)
            {
                var currentTurn = dialogueTurnsQueue.Dequeue();

                dialogueUI.SetCharacterInfo(currentTurn.Character);
                dialogueUI.ClearDialogueArea();
                dialogueUI.SetDialogArea(currentTurn.Dialogue_Line);
                

                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return null;
            }

            dialogueUI.HideDialogBox();
            IsDialogInProgress = false;
        }

        
    }
}

