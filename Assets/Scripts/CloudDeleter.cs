using UnityEngine;

public class CloudDeleter : MonoBehaviour
{
    public Transform cam;

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
