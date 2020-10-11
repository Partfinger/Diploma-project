using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorDevice : Unit, IInput, ITickable, IMinMax, IMovable
{
    IOutput input;
    public IOutput Input
    {
        get
        {
            return input;
        }
        set
        {
            input = value;
        }
    }
    public float Min { get; set; }
    public float Max { get; set; }

    public Indicator[] indicators;

    public void Tick()
    {
        float inp = input.Output;
        for (int i =0; i < indicators.Length; i++)
        {
            indicators[i].Set(inp);
        }
    }

    public void StartSimulation()
    {
        for (int i = 0; i < indicators.Length; i++)
        {
            indicators[i].Prepare();
        }
    }

    public void StopSimulation()
    {
        return;
    }
}
