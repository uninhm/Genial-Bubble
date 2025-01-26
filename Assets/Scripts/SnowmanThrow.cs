using UnityEngine;

public class SnowmanThrow : MonoBehaviour
{
    public GameObject Snowball;
    public float launchForce = 5f;
    public float launchAngle = 90f;
    public float fireRate = 0.5f; // Tirs par seconde
    private float nextFireTime = 0f;
    public Transform SnowmanHand;
    Death death;
    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        death = GetComponent<Death>();
    }
    void Update()
    {
        if (Time.time >= nextFireTime && !death.IsDead())
        {
            LaunchBall();
            nextFireTime = Time.time + 1f / fireRate;
        }

    }
    void LaunchBall()
    {
        anim.Play("SnowmanThrowing");
        GameObject ball = Instantiate(Snowball, SnowmanHand.position, Quaternion.identity);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        // Calculer la direction toujours vers la gauche
        Vector2 launchDirection = new Vector2(-Mathf.Cos(launchAngle * Mathf.Deg2Rad), Mathf.Sin(launchAngle * Mathf.Deg2Rad));

        rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);

        Destroy(ball, 5f);
    }
}
