using System;
using UnityEngine;

public class SpiderGenerator : MonoBehaviour
{
    public bool activated = false;
    public GameObject Spider;
    public Transform SpawnPointSpider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!activated && collider.gameObject.name == "Player")
        {
            activated = true;
            Instantiate(Spider, SpawnPointSpider.position, transform.rotation);
        }
    }

}
