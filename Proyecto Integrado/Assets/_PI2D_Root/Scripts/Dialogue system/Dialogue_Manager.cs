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

        private Queue<Dialogue_Turn> dialogueTurnsQueue;

        private void Awake()
        {
            Instance = this;
            HideDialogBox();
        }

        public void StartDialogue(Dialogue_Round dialogue)
        {
            dialogueTurnsQueue = new Queue<Dialogue_Turn>(dialogue.Dialogue_Turns);
            StartCoroutine(DialogueCoroutine());
        }

        private IEnumerator DialogueCoroutine()
        {
            ShowDialogBox();

            while (dialogueTurnsQueue.Count > 0)
            {
                var currentTurn = dialogueTurnsQueue.Dequeue();

                SetCharacterInfo(currentTurn.Character, GetCharacterPhoto());
                ClearDialogueArea();

                dialogArea.text = currentTurn.Dialogue_Line;

                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return null;
            }

            HideDialogBox();
        }

        // Dialogue UI
        [SerializeField] private RectTransform dialogBox;
        [SerializeField] private Image characterPhoto;
        [SerializeField] private TextMeshProUGUI characterName;
        [SerializeField] private TextMeshProUGUI dialogArea;

        public void ShowDialogBox()
        {
            dialogBox.gameObject.SetActive(true);
        }

        public void HideDialogBox()
        {
            dialogBox.gameObject.SetActive(false);
        }

        public Image GetCharacterPhoto()
        {
            return characterPhoto;
        }

        public void SetCharacterInfo(Dialogue_Character character, Image characterPhoto)
        {
            if (character == null) return;

            characterPhoto.sprite = character.Photo;
            characterName.text = character.Name;
        }

        public void ClearDialogueArea()
        {
            dialogArea.text = string.Empty;
        }
    }
}

