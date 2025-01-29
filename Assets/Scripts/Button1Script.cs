using UnityEngine;

public class Button1Script : Activable
{
    public GameObject spikes;
    public float delay;
    public float disableTime;

    void DeactivateSpikes()
    {
        spikes.SetActive(false);
    }

    void ActivateSpikes()
    {
        spikes.SetActive(true);
    }
    public override void Activate()
    {
        if (!activated)
        {
            activated = true;
            Invoke("DeactivateSpikes", delay);
            Invoke("ActivateSpikes", delay+disableTime);
        }
    }

    public override void Reset()
    {
        base.Reset();
        CancelInvoke();
        ActivateSpikes();
    }
}
