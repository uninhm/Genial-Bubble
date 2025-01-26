using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public Transform cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ParentCheckpointScript p = GetComponentInParent<ParentCheckpointScript>();
            p.checkpointPos = transform.position;
            p.cameraPos = cam.position;
        }
    }
}
