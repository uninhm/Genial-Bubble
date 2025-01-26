using UnityEngine;
using UnityEngine.Tilemaps;

public class WireScript : MonoBehaviour
{
    protected Tilemap wire;
    protected bool active = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wire = GetComponent<Tilemap>();
    }

    public bool IsActive()
    {
        return active;
    }

    public void Activate()
    {
        wire.color = Color.green;
        active = true;
    }

    public void Deactivate()
    {
        wire.color = Color.white;
        active = false;
    }
}

public class InputWireScript : WireScript
{
    public ButtonActivate button;

    // Update is called once per frame
    void Update()
    {
        if (button.IsActive())
        {
            Activate();
        } else
        {
            Deactivate();
        }
    }
}
