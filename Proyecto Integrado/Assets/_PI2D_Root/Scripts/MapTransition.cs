using Unity.Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class MapTransition : MonoBehaviour
{
    [SerializeField] BoxCollider2D mapBoundary;
     CinemachineConfiner2D confiner;
    [SerializeField]  Direction direction;    
    [SerializeField]  float additivePos = 2f;  

    enum Direction { Up, Down, Left, Right }    

    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Player"))
       {
            confiner.BoundingShape2D = mapBoundary;
            UpdatePlayerPosition(collision.gameObject);
       }
    }

    private void UpdatePlayerPosition(GameObject player)
    {
       Vector3 newPos = player.transform.position;

        switch (direction)
        {
           case Direction.Up:
                newPos.y += additivePos; 
                break;
           case Direction.Down:
                newPos.y -= additivePos;
                break;
           case Direction.Left:
                newPos.x -= additivePos;
                break;    
           case Direction.Right:
                newPos.x += additivePos;
                break;
        }

        player.transform.position = newPos;

    }





}




