using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    private void Start()
    {
        string spawnName = GameManager.Instance.lastSpawnPoint;

        GameObject spawnPoint = GameObject.Find(spawnName);

        if (spawnPoint != null)
            transform.position = spawnPoint.transform.position;

    }










}
