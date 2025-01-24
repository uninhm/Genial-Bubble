using UnityEngine;
using UnityEngine.InputSystem;

public class CircleController : MonoBehaviour
{
    int jumpForce = 5;
    InputAction jumpAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {

        if (jumpAction.WasPressedThisFrame())
        {
            Debug.Log("W key down");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }
}
