using UnityEngine;

public class SnowmanThrow : MonoBehaviour
{
    public GameObject Snowball;
    public float launchForce = 6f;
    public float launchAngle = 90f;
    public float fireRate = 0.5f; // Tirs par seconde
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            LaunchBall();
            nextFireTime = Time.time + 1f / fireRate;
        }

    }
    void LaunchBall()
    {
        GameObject ball = Instantiate(Snowball, transform.position, Quaternion.identity);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        // Calculer la direction toujours vers la gauche
        Vector2 launchDirection = new Vector2(-Mathf.Cos(launchAngle * Mathf.Deg2Rad), Mathf.Sin(launchAngle * Mathf.Deg2Rad));

        rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);

        Destroy(ball, 5f);
    }
}
