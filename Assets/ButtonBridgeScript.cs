using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class ButtonBridgeScript : Activable
{
    public GameObject block;
    override public void Activate()
    {
        if (!activated)
        {
            block.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            block.GetComponent<Rigidbody2D>().gravityScale = 1;
            activated = true;
        }
    }

    override public void Reset()
    {
        activated = false;
    }
}