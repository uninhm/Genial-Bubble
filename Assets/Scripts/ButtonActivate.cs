using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    public GameObject block;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        block.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
