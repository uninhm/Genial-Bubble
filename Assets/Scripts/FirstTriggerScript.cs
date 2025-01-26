using UnityEngine;

public class FirstTriggerScript : Resetable
{
    public Transform cam;
    public float speed = 1;
    PlayerController playerController;
    bool moving = false;
    public bool activated = false;
    public float targetX = 23;
    public Activable button;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!activated && collider.gameObject.name == "Player")
        {
            moving = true;
            playerController = collider.gameObject.GetComponent<PlayerController>();
            playerController.stopped = true;
            Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
            rb.linearVelocity = rb.linearVelocity * 0.1f;
            activated = true;
        }
    }

    private void Update()
    {
        if (moving)
        {
            if (cam.position.x < targetX)
            {
                cam.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                moving = false;
                playerController.stopped = false;
            }
        }
    }

    override public void Reset()
    {
        if (!button.activated) activated = false;
    }
}
