using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public Unit input;
    public float output;
    public bool inQueue;

    public virtual bool AddParentsToEvent(ref Queue<Unit> unit)
    {
        if (!inQueue)
        {
            unit.Enqueue(input);
            inQueue = true;
            return true;
        }
        return false;
    }

    public abstract void Tick();
}