using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntryUnit : UnitOld
{
    public UnitOld input;

    public override bool AddParentsToEvent(ref Queue<UnitOld> unit)
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