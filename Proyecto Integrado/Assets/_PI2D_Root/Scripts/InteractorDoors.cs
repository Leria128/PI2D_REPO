using System;
using UnityEngine;

public class PlayerInteractor  : MonoBehaviour
{
   public float interactionrange = 1f;
    public LayerMask interactableLayer;

    private Doors currentDoor;

    void Update()
    {
        DetectDoor();

        if(currentDoor != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentDoor.TryUseDoor();
            }
        }
        
    }

    void DetectDoor()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position,interactionrange,interactableLayer);

        if (hit != null)
            currentDoor = hit.GetComponent<Doors>();

        else
            currentDoor = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,interactionrange);
    }

}
