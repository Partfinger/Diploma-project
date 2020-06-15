using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Динамічна ланка
/// </summary>
public class DUnit : EntryUnit
{
    public TransferFunction funct;

    public override void Tick()
    {
        output = funct.Transform(input.output);
    }
}
