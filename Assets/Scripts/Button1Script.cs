using Unity.VisualScripting;
using UnityEngine;

public class Button1Script : Activable
{
    public GameObject spikes;
    public override void Activate()
    {
        if (!activated)
        {
            activated = true;
            spikes.SetActive(true);
        }
    }
}
