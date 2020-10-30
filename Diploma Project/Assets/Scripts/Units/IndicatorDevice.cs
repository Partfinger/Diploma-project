using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorDevice : Unit, IInputable, ITickable, IMinMax, ISimulatable
{
    IOutputable input;
    public IOutputable Input
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
        GetComponent<Collider>().enabled = false;
        for (int i = 0; i < indicators.Length; i++)
        {
            indicators[i].Prepare();
        }
    }

    public void StopSimulation()
    {
        GetComponent<Collider>().enabled = true;
    }

    public override void Validate(List<string> logger)
    {
        if (Input == null)
            logger.Add($"Не призначений вхід для {Name}");

        if (Max < Min)
        {
            logger.Add($"Для {Name} значення max менше ніж min!");
        }
        else if (Max == Min)
        {
            logger.Add($"Для {Name} min і max мають однакові значення!");
        }
    }
}
