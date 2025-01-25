using UnityEngine;

public class PlayerDammage : MonoBehaviour
{
    public float respawnDelay = 1f;
    public float fadeOutDuration = 1f;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private SpriteRenderer spriteRenderer;
    private float fadeStartTime;
    private bool isFading = false;
    private bool isWaitingToRespawn = false;
    public Transform cam;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isFading)
        {
            float elapsedTime = Time.time - fadeStartTime;
            if (elapsedTime < fadeOutDuration)
            {
                float alpha = 1f - (elapsedTime / fadeOutDuration);
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
            }
            else
            {
                isFading = false;
                gameObject.SetActive(false);
                isWaitingToRespawn = true;
                Invoke("Respawn", respawnDelay);
            }
        }
    }

    public void DisappearAndRespawn()
    {
        if (!isFading && !isWaitingToRespawn)
        {
            isFading = true;
            fadeStartTime = Time.time;
            GetComponent<PlayerController>().stopped = true;
        }
    }

    void Respawn()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        gameObject.SetActive(true);
        isWaitingToRespawn = false;
        cam.position = new Vector3(0, 0, -10);
        GameObject.Find("firstTrigger").GetComponent<FirstTriggerScript>().activated = false;
        GetComponent<PlayerController>().stopped = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            DisappearAndRespawn();
        }
    }
}
