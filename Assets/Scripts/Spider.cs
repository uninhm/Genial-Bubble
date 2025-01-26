using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 5f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        if (speed != 0)
        {
        float pingPong = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPosition + Vector3.right * pingPong;
        }
    }
}
