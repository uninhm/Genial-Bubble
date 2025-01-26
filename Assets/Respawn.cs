using UnityEngine;

public class Mob : Resetable
{
    Vector3 spawnPoint; // Point de respawn
    Quaternion spawnRotation;
    public GameObject prefab;

    void Start()
    {
        spawnPoint = transform.position;
        spawnRotation = transform.rotation;
    }

    override public void Reset()
    {
        Instantiate(prefab, spawnPoint, spawnRotation);
    }
}
