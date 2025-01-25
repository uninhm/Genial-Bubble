using UnityEngine;

public class KynematicOnCollision : MonoBehaviour
{
    Rigidbody2D rb;
    bool falled = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocityY > 0.01) falled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "fondation" && falled)
            rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
