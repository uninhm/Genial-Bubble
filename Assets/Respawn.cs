using UnityEngine;

public class Mob : MonoBehaviour
{
    public Vector3 spawnPoint; // Point de respawn

    void Start()
    {
        // Mémorise le point de spawn initial si non défini
        if (spawnPoint == Vector3.zero)
        {
            spawnPoint = transform.position;
        }
    }

    public void RespawnObject()
    {
        // Repositionne l'objet à son point de spawn
        transform.position = spawnPoint;

        // Réactive l'objet si nécessaire
        gameObject.SetActive(true);
    }
}
