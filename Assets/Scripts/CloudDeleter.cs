using UnityEngine;

public class CloudDeleter : MonoBehaviour
{
    public Transform cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < cam.position.x - 12)
            Destroy(gameObject);
        Vector3 pos = transform.position;
        pos.x -= 0.2f * Time.deltaTime;
        transform.position = pos;
    }
}
