using UnityEngine;

public class ThrowedResolveBubble : MonoBehaviour
{
    public float speed;
    PlayerController playerCon;
    Rigidbody2D rb;
    public Transform cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().Play("BubblePop");
        rb.linearVelocity = Vector3.zero;

        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Jump(10);
        }
    }
}
