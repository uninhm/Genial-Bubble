using Unity.VisualScripting;
using UnityEngine;

public class Button1Script : Activable
{
    public GameObject spikes;
    public float delay;

    void DeactivateSpikes()
    {
        spikes.SetActive(false);
    }
    public override void Activate()
    {
        if (!activated)
        {
            activated = true;
            Invoke("DeactivateSpikes", delay);
        }
    }
}
