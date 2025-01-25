using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    Transform playerTr;
    Transform tr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTr.position.x > tr.position.x + 6.5)
            tr.position = new Vector3(playerTr.position.x - 6.5f, tr.position.y, tr.position.z);
        else if (playerTr.position.x < tr.position.x - 6.5)
            tr.position = new Vector3(playerTr.position.x + 6.5f, tr.position.y, tr.position.z);
    }
}
