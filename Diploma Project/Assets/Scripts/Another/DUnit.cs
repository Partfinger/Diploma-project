using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DUnit : Unit
{
    public TransferFunction funct;

    public override void Tick()
    {
        output = funct.Transform(input.output);
    }
}
