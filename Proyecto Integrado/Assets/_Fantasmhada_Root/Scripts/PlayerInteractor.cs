using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    NPCDialogue currentNPC;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (currentNPC != null && currentNPC.CanInteract)
        {
            currentNPC.Interact();
            AudioManager.Instance.PlaySFX(0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out NPCDialogue npc))
        {
            currentNPC = npc;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out NPCDialogue npc))
        {
            if (npc == currentNPC)
                currentNPC = null;
        }
    }
}
