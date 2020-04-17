using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : Unit
{
    public override void Tick()
    {
        return;
    }

    public override bool AddParentsToEvent(ref Queue<Unit> unit)
    {
        return false;
    }
}
