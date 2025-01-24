using UnityEngine;
using UnityEngine.InputSystem;

public class CircleController : MonoBehaviour
{
    int jumpForce = 5;
    InputAction jumpAction;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (jumpAction.WasPressedThisFrame())
        {
            Debug.Log("W key down");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
