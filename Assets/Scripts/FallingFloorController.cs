using UnityEngine;

public class FallingFloorController : Resetable
{
    public float delay = 3;
    Vector3 origPos;
    Quaternion origRot;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        origPos = transform.position;
        origRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20)
            gameObject.SetActive(false);
    }

    void Fall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && collision.transform.position.y > rb.position.y)
            Invoke("Fall", delay);
        if (collision.gameObject.name == "Killer")
            gameObject.SetActive(false);
    }

    override public void Reset()
    {
        CancelInvoke();
        gameObject.SetActive(true);
        transform.position = origPos;
        transform.rotation = origRot;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
