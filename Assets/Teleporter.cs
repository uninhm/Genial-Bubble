using UnityEngine;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{
    public Collider2D destination;
    public string mainLevel;
    InputAction Interact;
    private bool playerInRange = false;

    private void Start()
    {
        Interact = InputSystem.actions.FindAction("Interact");
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            mainLevel = player.transform.position.y <= -8 ? "down" : "up";
        }
        Debug.Log(mainLevel);
    }

    private void Update()
    {
        if (playerInRange && Interact.WasPressedThisFrame())
        {
            TeleportPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInRange = false;
        }
    }

    private void TeleportPlayer()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            player.transform.position = destination.bounds.center;
            mainLevel = (mainLevel == "up") ? "down" : "up";
        }
    }
}
