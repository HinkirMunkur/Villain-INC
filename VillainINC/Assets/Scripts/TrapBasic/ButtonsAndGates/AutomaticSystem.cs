using UnityEngine;

public abstract class AutomaticSystem : MonoBehaviour
{
    public abstract void RunSystem();

    public virtual void ExitSystem() { }
}
