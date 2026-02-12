using UnityEngine;

namespace DialogueSystem_V
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Collider2D doorCollider;

        public void UnlockDoor()
        {
            doorCollider.enabled = false;
            Debug.Log("Puerta desbloqueada");
        }

    }
}
