using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{
    public string doorID;
    public string sceneToLoad;
    public string spawnPointName;
    //public string requiredKey; //Opción

    public bool isLocked = false;


    public void TryUseDoor()
    {
       

        if (isLocked || GameManager.Instance.IsDoorLocked(doorID));
        {
            Debug.Log("The door is locked");
                return;
        }

        //Guarda el spawn para la escena destino
        GameManager.Instance.lastSpawnPoint = spawnPointName;

        //Cambia de escena
        SceneManager.LoadScene(sceneToLoad);


    }



}
