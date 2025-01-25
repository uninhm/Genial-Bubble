using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void takeShot()
    {
        Destroy(gameObject);
    }
}
