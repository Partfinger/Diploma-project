using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DUnit : EntryUnit
{
    public TransferFunction funct;

    private void Start()
    {
        funct = new SForm(new float[1], new float[1]);
    }

    public override void Tick()
    {
        output = funct.Transform(input.output);
    }
}
