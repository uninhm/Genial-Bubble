using UnityEngine;

public class ThrowedBubble : MonoBehaviour
{

    public float speed;
    PlayerController playerCon;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCon = GameObject.Find("Player").GetComponent<PlayerController>();
        rb.linearVelocity = Vector3.right * playerCon.direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
