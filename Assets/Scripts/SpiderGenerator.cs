using UnityEngine;

public class SpiderGenerator : Resetable
{
    public bool activated = false;
    public GameObject Spider;
    public Transform SpawnPointSpider;
    private GameObject currentSpider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player" && !activated)
        {
            SpawnSpider();
        }
    }
    private void SpawnSpider()
    {
        if (currentSpider != null)
        {
            Destroy(currentSpider);
        }
        activated = true;
        currentSpider = Instantiate(Spider, SpawnPointSpider.position, transform.rotation);
    }
    override public void Reset()
    {
        activated = false;
    }
}
