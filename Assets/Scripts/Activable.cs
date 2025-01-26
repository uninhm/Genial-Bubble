using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

abstract public class Activable : Resetable
{
    public bool activated;
    abstract public void Activate();

    public override void Reset()
    {
        activated = false;
    }
}
