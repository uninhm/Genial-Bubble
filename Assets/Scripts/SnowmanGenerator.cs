using System;
using UnityEngine;

public class SnowmanGenerator : Resetable
{
    public bool activated = false;
    public GameObject Snowman;
    public Transform SpawnPointSnowman;
    private GameObject CurrentSnowman;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!activated && collider.gameObject.name == "Player")
        {
            SpawnSnowman();
        }
    }
    private void SpawnSnowman()
    {
        if (CurrentSnowman != null)
        {
            Destroy(CurrentSnowman);
        }
        activated = true;
        CurrentSnowman = Instantiate(Snowman, SpawnPointSnowman.position, transform.rotation);
    }

    override public void Reset()
    {
        activated = false;
    }
}
