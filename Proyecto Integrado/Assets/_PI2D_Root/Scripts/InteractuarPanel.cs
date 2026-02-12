using UnityEngine;

public class InteractuarPanel : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    private bool isPlayerNearby = false;

    public void OnInteract()
    {

    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            uiPanel.SetActive(!uiPanel.activeSelf);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            isPlayerNearby=true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            isPlayerNearby=false;   
    }

}
