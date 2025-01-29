using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public Transform cam;

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
