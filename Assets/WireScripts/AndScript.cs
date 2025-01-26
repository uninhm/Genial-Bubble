using UnityEngine;
using UnityEngine.Tilemaps;

public class AndScript : WireScript
{
    public WireScript a; public WireScript b;
    //Tilemap wire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
/*    void Start()
    {
        wire = GetComponent<Tilemap>();
    }*/

    // Update is called once per frame
    void Update()
    {
        if (a.IsActive() && b.IsActive())
            Activate();
        else Deactivate();
    }
}
