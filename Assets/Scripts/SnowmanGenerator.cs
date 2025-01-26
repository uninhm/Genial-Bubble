using System;
using UnityEngine;

public class SnowmanGenerator : Resetable
{
    public bool activated = false;
    public GameObject Snowman;
    public Transform SpawnPointSnowman;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!activated && collider.gameObject.name == "Player")
        {
            activated = true;
            Instantiate(Snowman, SpawnPointSnowman.position, transform.rotation);
        }
    }

    override public void Reset()
    {
        activated = false;
    }
}
