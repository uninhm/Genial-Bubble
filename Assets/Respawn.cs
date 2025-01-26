using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 spawnPoint;

    void Start()
    {
        if (spawnPoint == Vector3.zero)
        {
            spawnPoint = transform.position;
        }
    }

    public void RespawnObject()
    {
        transform.position = spawnPoint;

        gameObject.SetActive(true);
    }
}
