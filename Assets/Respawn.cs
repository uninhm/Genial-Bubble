using UnityEngine;

public class Mob : MonoBehaviour
{
    public Vector3 spawnPoint; // Point de respawn

    void Start()
    {
        // M�morise le point de spawn initial si non d�fini
        if (spawnPoint == Vector3.zero)
        {
            spawnPoint = transform.position;
        }
    }

    public void RespawnObject()
    {
        // Repositionne l'objet � son point de spawn
        transform.position = spawnPoint;

        // R�active l'objet si n�cessaire
        gameObject.SetActive(true);
    }
}
