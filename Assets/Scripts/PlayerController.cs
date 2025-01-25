using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int jumpForce = 15;
    public int playerSpeed = 10;
    public int maxSpeed = 6;
    public float floorDistance;
    public bool stopped = false;
    bool wasTouchingFloor;

    public Transform shootingPoint;
    public GameObject OffensiveBubble;
    public GameObject ResolveBubble;
    private GameObject currentBubble;

    InputAction jumpAction;
    InputAction moveAction;
    InputAction throwOffensiveBubble;
    InputAction throwResolveBubble;

    Rigidbody2D rb;
    Collider2D col;
    Transform tr;
    Animator anim;

    public int direction = 1;

    public float CooldownTimeOffensive;
    float cooldownUntilNextPressOffensive;

    public float CooldownTimePassive;
    float cooldownUntilNextPressPassive;
    public bool IsGrounded()
    {
        if (Mathf.Abs(rb.linearVelocityY) > 0.01) return false;
        return true;
    }

    public void Jump(int force)
    {
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        anim.Play("Jump");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction = InputSystem.actions.FindAction("Move");
        throwOffensiveBubble = InputSystem.actions.FindAction("Attack");
        throwResolveBubble = InputSystem.actions.FindAction("Throw");
        rb = GetComponent<Rigidbody2D>();
        col = rb.GetComponent<Collider2D>();
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isTouchingFloor = IsGrounded();
        if (!stopped)
        {
            if (isTouchingFloor && (jumpAction.WasPressedThisFrame() || jumpAction.IsPressed() && !wasTouchingFloor))
            {
                Jump(jumpForce);
            }
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
                Vector2 vel2 = rb.linearVelocity;
                vel2.x = (float)(vel2.x - vel2.x * 1.5 * Time.deltaTime);
            }
            if (throwResolveBubble.WasPressedThisFrame() && cooldownUntilNextPressPassive < Time.time)
            {
                if (currentBubble != null)
                {
                    currentBubble.GetComponent<Animator>().Play("BubblePop");
                    Destroy(currentBubble, 2f);
                }

                cooldownUntilNextPressPassive = Time.time + CooldownTimePassive;
                currentBubble = Instantiate(ResolveBubble, shootingPoint.position, Quaternion.identity);
                anim.Play("throw");
            }
            if (throwOffensiveBubble.WasPressedThisFrame() && cooldownUntilNextPressOffensive < Time.time)
            {
                cooldownUntilNextPressOffensive = Time.time + CooldownTimeOffensive;
                Instantiate(OffensiveBubble, shootingPoint.position, transform.rotation);
                anim.Play("throw");
            }
        }

        Vector2 vel = rb.linearVelocity;
        vel.x = Mathf.Clamp(vel.x, -maxSpeed, maxSpeed);
        rb.linearVelocity = vel;
        anim.SetFloat("Speed", Mathf.Abs(vel.x));
        anim.SetBool("Grounded", isTouchingFloor);

        wasTouchingFloor = isTouchingFloor;
    }
}
