using UnityEngine;
using UnityEngine.InputSystem;

public class CircleController : MonoBehaviour
{
    public int jumpForce = 15;
    public int playerSpeed = 10;
    public int maxSpeed = 6;
    bool wasTouchingFloor;
    InputAction jumpAction;
    InputAction moveAction;
    Rigidbody2D rb;
    Collider2D col;
    Collider2D floorCol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        col = rb.GetComponent<Collider2D>();
        floorCol = GameObject.Find("Floor").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isTouchingFloor = col.IsTouching(floorCol);
        if (isTouchingFloor && (jumpAction.WasPressedThisFrame() || jumpAction.IsPressed() && !wasTouchingFloor))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        Vector2 vel = rb.linearVelocity;
        if (moveAction.IsPressed())
        {
            rb.AddForce(moveAction.ReadValue<Vector2>() * playerSpeed);
        }
        else
        {
            vel.x = (float)(vel.x - vel.x * 1.5 * Time.deltaTime);
        }
        // rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
        vel.x = Mathf.Clamp(vel.x, -maxSpeed, maxSpeed);
        rb.linearVelocity = vel;

        wasTouchingFloor = isTouchingFloor;

        /*        if (jumpAction.WasPressedThisFrame())
                {
                    if (col.IsTouching(floorCol))
                        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
                Vector2 vel = rb.linearVelocity;
                if (moveAction.IsPressed())
                {
                    vel.x = playerSpeed * moveAction.ReadValue<Vector2>().x;
                }
                else
                {
                    vel.x = (float)(vel.x - vel.x * 0.95 * Time.deltaTime);
                }
                // rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
                vel.x = Mathf.Clamp(vel.x, -maxSpeed, maxSpeed);
                rb.linearVelocity = vel;*/
    }
}
