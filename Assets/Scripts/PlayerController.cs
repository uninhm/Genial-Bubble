using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int jumpForce = 15;
    public int playerSpeed = 10;
    public int maxSpeed = 6;
    public float floorDistance;
    bool wasTouchingFloor;

    public Transform shootingPoint;
    public GameObject OffensiveBubble;

    InputAction jumpAction;
    InputAction moveAction;
    InputAction throwOffensiveBubble;

    Rigidbody2D rb;
    Collider2D col;
    Transform tr;
    Animator anim;

    public int direction = 1;

    public float CooldownTime;
    float cooldownUntilNextPress;
    public bool IsGrounded()
    {
        if (Mathf.Abs(rb.linearVelocityY) > 0.01) return false;
        return true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction = InputSystem.actions.FindAction("Move");
        throwOffensiveBubble = InputSystem.actions.FindAction("Attack");
        rb = GetComponent<Rigidbody2D>();
        col = rb.GetComponent<Collider2D>();
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isTouchingFloor = IsGrounded();
        if (isTouchingFloor && (jumpAction.WasPressedThisFrame() || jumpAction.IsPressed() && !wasTouchingFloor))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.Play("Jump");
        }
        Vector2 vel = rb.linearVelocity;
        if (moveAction.IsPressed())
        {
            rb.AddForce(moveAction.ReadValue<Vector2>() * playerSpeed);
            if (moveAction.ReadValue<Vector2>().x > 0)
                direction = 1;
            else direction = -1;
            tr.localScale = new Vector3(direction, 1, 1);
        }
        else
        {
            vel.x = (float)(vel.x - vel.x * 1.5 * Time.deltaTime);
        }
        if(throwOffensiveBubble.WasPressedThisFrame() && cooldownUntilNextPress < Time.time)
        {
            cooldownUntilNextPress = Time.time + CooldownTime;
            Instantiate(OffensiveBubble, shootingPoint.position, transform.rotation);
            anim.Play("throw");
        }

        vel.x = Mathf.Clamp(vel.x, -maxSpeed, maxSpeed);
        rb.linearVelocity = vel;
        anim.SetFloat("Speed", Mathf.Abs(vel.x));
        anim.SetBool("Grounded", isTouchingFloor);

        wasTouchingFloor = isTouchingFloor;
    }
}
