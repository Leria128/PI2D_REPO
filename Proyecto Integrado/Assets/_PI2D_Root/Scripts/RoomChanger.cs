using UnityEngine;

public class RoomChanger : MonoBehaviour
{

    [SerializeField] Transform teleportPoint;
    [SerializeField] Camera mainCamera;
    [SerializeField] Vector3 camPositionToSet;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.position = teleportPoint.position;
            mainCamera.transform.position = camPositionToSet;
        }
    }
}
