using UnityEngine;

public class LogicalSpike : MonoBehaviour
{
    public WireScript wire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(wire.IsActive());
    }
}
