using UnityEngine;

public class ThrowedBubble : MonoBehaviour
{

    public float speed;
    PlayerController playerCon;
    Rigidbody2D rb;
    public Transform cam;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerCon = GameObject.Find("Player").GetComponent<PlayerController>();
        rb.linearVelocity = Vector3.right * playerCon.direction * speed;
        if (playerCon.direction == -1)
        {
            transform.Rotate(Vector3.forward * 180);
        }
        cam = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - cam.position.x) > 12)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<Animator>().Play("InsideBubble");
            enemy.transform.position = transform.position;
            Destroy(gameObject);
            enemy.GetComponent<Death>().Die();
        }
    }
}
