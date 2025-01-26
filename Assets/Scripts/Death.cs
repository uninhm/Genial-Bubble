using UnityEngine;

public class Death : MonoBehaviour
{
    bool dead = false;

    public bool IsDead()
    {
        return dead;
    }
    public void Die()
    {
        dead = true;
        GetComponent<Collider2D>().enabled = false;
    }
}
