using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comparator : Unit
{
    public Unit another;

    public override void Tick()
    {
        output = input.output - another.output;
        if (Mathf.Abs(output) < 0.0001f)
            output = 0.0f;
    }

    private void Start()
    {
        output = input.output - another.output;
    }

}
