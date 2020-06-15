using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public float output;
    public bool inQueue;

    public virtual bool AddParentsToEvent(ref Queue<Unit> unit)
    {
        inQueue = true;
        return true;
    }

    public abstract void Tick();

}