using UnityEngine;

abstract public class Activable : Resetable
{
    public bool activated;
    abstract public void Activate();

    public override void Reset()
    {
        activated = false;
    }
}
