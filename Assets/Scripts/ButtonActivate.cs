using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class ButtonActivate : Resetable
{
    Rigidbody2D rb;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Collider2D buttonCollider;
    private GameObject bubble;
    PlayerController player;

    Activable[] activables;

    void Start()
    {
        activables = GetComponents<Activable>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public bool IsActive()
    {
        return bubble != null;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (bubble != null) return;
        foreach (var a  in activables)
            if (a != this)
                a.Activate();
        if (other.gameObject.CompareTag("Projectile"))
        {
            rb=other.gameObject.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector3.zero;
            buttonCollider = GetComponent<Collider2D>();
            initialPosition = buttonCollider.bounds.center;
            //initialPosition.z = 0.5f;
            other.transform.position = initialPosition;
            bubble = other.gameObject;
            bubble.GetComponent<Animator>().Play("BubbleIdle");
            player.DetachBubble();
        }
    }

    public override void Reset()
    {
        Destroy(bubble);
        foreach (var a in activables)
            if (a != this)
                a.Reset();
    }
}   
