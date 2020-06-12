using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntryUnit : Unit
{
    public Unit input;

    public override bool AddParentsToEvent(ref Queue<Unit> unit)
    {
        if (!inQueue)
        {
            unit.Enqueue(input);
            inQueue = true;
            return true;
        }
        return false;
    }

}