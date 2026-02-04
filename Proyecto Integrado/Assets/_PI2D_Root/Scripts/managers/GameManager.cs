using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

    public string lastSpawnPoint = "Spawn_Default";

    private Dictionary< string, bool> doorStates = new Dictionary< string, bool >();    

    private void Awake()
    {
        //Singletone
        if (Instance == null)
        {
            Instance = this;    
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDoorState(string doorID, bool isLocked)
    {
        if (doorStates.ContainsKey(doorID))
            doorStates[doorID] = isLocked;
        else doorStates.Add(doorID, isLocked);
        
    }

    public bool IsDoorLocked(string doorID)
    {
        if (doorStates.ContainsKey(doorID))
            return doorStates[doorID];

        return false;   
    }



}
