using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEntity : EntryUnit
{
    public List<ControlLaw> laws = new List<ControlLaw>();

    public override void Tick()
    {
        int l = laws.Count;
        float control = 0;
        for (int i = 0; i < l; i++)
        {
            control += laws[i].SetTask(input.output);
        }
        output = control;
    }
}
