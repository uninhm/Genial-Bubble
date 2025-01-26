using UnityEngine;

public class Resetable : MonoBehaviour
{
    virtual public void Reset()
    {
    }
}

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
    private ParentCheckpointScript checkpoints;
    public Resetable[] resetOnRespawn;
    Sprite initialSprite;
    BoxCollider2D col;
    Vector2 initialSize, initialOffset;



    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        spriteRenderer = GetComponent<SpriteRenderer>();
        checkpoints = GameObject.Find("Checkpoints").GetComponent<ParentCheckpointScript>();
        initialSprite = spriteRenderer.sprite;
        col = GetComponent<BoxCollider2D>();
        initialOffset = col.offset;
        initialSize = col.size;
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
        transform.position = checkpoints.checkpointPos;
        transform.rotation = initialRotation;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        spriteRenderer.sprite = initialSprite;
        col.size = initialSize;
        col.offset = initialOffset;
        gameObject.SetActive(true);
        isWaitingToRespawn = false;
        cam.position = checkpoints.cameraPos;
        /*GameObject.Find("firstTrigger").GetComponent<FirstTriggerScript>().activated = false;
        GameObject.Find("SpiderTrigger").GetComponent<SpiderGenerator>().activated = false;*/
        foreach (Resetable r in resetOnRespawn)
            r.Reset();
        GetComponent<PlayerController>().stopped = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DisappearAndRespawn();
        }
    }
}
