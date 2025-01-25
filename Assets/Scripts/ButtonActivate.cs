using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    public GameObject block;
    Rigidbody2D rb;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Collider2D buttonCollider;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        block.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        block.GetComponent<Rigidbody2D>().gravityScale = 1;
        if (other.gameObject.CompareTag("GameController"))
        {
            rb=other.gameObject.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector3.zero;
            buttonCollider = GetComponent<Collider2D>();
            initialPosition = buttonCollider.bounds.center;
            other.transform.position = initialPosition;
        }
    }
}   
