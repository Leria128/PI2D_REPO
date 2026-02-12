using System.Runtime.CompilerServices;
using UnityEngine;

namespace DialogueSystem_V
{
    public class Dialogue_Trigger : MonoBehaviour
    {
        [SerializeField] private Dialogue_Round dialogue;

        [ContextMenu("Trigger Dialogue")]

        public void TriggerDialogue() 
        {
         DialogueManager.Instance.StartDialogue(dialogue);

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) 
            {
                TriggerDialogue ();
            }
        }
    }
}
