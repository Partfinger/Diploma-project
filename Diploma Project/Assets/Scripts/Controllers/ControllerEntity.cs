using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEntity : Unit
{
    public ControlLaw[] laws;

    public override void Tick()
    {
        float control = 0;
        for (int i = 0; i < laws.Length; i++)
        {
            control += laws[i].SetTask(input.output);
        }
        output = control;
    }
}
