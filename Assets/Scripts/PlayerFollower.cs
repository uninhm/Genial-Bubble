using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    Transform playerTr;
    Transform tr;
    public float maxDistanceR = 4.5f;
    public float maxDistanceL = 7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTr.position.x > tr.position.x + maxDistanceR)
            tr.position = new Vector3(playerTr.position.x - maxDistanceR, tr.position.y, tr.position.z);
        else if (playerTr.position.x < tr.position.x - maxDistanceL)
            playerTr.position = new Vector3(tr.position.x - maxDistanceL, playerTr.position.y, playerTr.position.z);
            // tr.position = new Vector3(playerTr.position.x + maxDistance, tr.position.y, tr.position.z);
    }
}
