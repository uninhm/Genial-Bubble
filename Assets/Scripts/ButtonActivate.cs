using UnityEngine;
using UnityEngine.UI;

public class ButtonActivate : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Collider2D buttonCollider;

    Activable[] activables;

    void Start()
    {
        activables = GetComponents<Activable>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var a  in activables)
            a.Activate();
        if (other.gameObject.CompareTag("Projectile"))
        {
            rb=other.gameObject.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector3.zero;
            buttonCollider = GetComponent<Collider2D>();
            initialPosition = buttonCollider.bounds.center;
            other.transform.position = initialPosition;
        }
    }
}   
