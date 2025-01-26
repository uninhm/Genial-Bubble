using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    Transform playerTr;
    Transform tr;
    Collider2D PlayerCD;
    public float maxDistanceR = 4.5f;
    public float maxDistanceL = 7f;
    private Camera cam;
    private string mainLevel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainLevel = GameObject.Find("teleporter_1").GetComponent<Teleport>().mainLevel;
        PlayerCD = GameObject.Find("Player").GetComponent<Collider2D>();
        cam = GetComponent<Camera>();
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTr.position.y<=-8 && mainLevel=="down"){
            cam.orthographicSize = 8;
            tr.position = new Vector3(7, -15.5f, tr.position.z);

        }else{
            cam.orthographicSize = 5;
            if (playerTr.position.x > tr.position.x + maxDistanceR)
                tr.position = new Vector3(playerTr.position.x - maxDistanceR, 0, tr.position.z);
            else if (playerTr.position.x < tr.position.x - maxDistanceL)
                playerTr.position = new Vector3(tr.position.x - maxDistanceL,0, playerTr.position.z);
                // tr.position = new Vector3(playerTr.position.x + maxDistance, tr.position.y, tr.position.z);
        }
    }
}
