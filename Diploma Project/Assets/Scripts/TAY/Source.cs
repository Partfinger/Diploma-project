using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : Unit
{
    public float task;

    public override void Tick()
    {
        return;
    }

    public override bool AddParentsToEvent(ref Queue<Unit> unit)
    {
        return false;
    }

    private void Awake()
    {
        output = task;
    }
    /*
    private void LateUpdate()
    {
        output = 0;
        enabled = false;
    }*/
}
