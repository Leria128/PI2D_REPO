using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace DialogueSystem_V
{
    public class Dialogue_UI : MonoBehaviour
    {
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

        public void SetCharacterInfo(Dialogue_Character character)
        {
            if (character == null) return;

            characterPhoto.sprite = character.Photo;
            characterName.text = character.Name;
        }

        public void SetDialogArea(string text)
        {
            dialogArea.text = text;
        }


        public void ClearDialogueArea()
        {
            dialogArea.text = string.Empty;
        }
    }
}
