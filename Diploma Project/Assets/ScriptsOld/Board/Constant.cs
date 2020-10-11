using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : UnitOld
{
    public float _const;

    private void Start()
    {
        output = _const;
    }

    public override void Tick()
    {
        return;
    }
}
