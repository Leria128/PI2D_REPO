using UnityEngine;
using UnityEngine.SceneManagement;

namespace DialogueSystem_V
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Collider2D doorCollider;
        [SerializeField] private string nextSceneName = "Final";


        private bool isUnlocked = false;

        public void UnlockDoor()
        {
            doorCollider.enabled = false;
            isUnlocked = true;
            Debug.Log("Puerta desbloqueada");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isUnlocked && collision.CompareTag("Player"))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }


}

