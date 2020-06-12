using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : EntryUnit
{
    public IndicatorEntity[] indicators;

    public float min, max;

    public override void Tick()
    {
        for (int i = 0; i < indicators.Length; i++)
        {
            indicators[i].Perfome(ref input.output);
        }
    }
}
