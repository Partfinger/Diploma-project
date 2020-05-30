using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DUnit : Unit
{
    public TF funct;

    public override void Tick()
    {
        output = funct.Transform(input.output);
    }
}
