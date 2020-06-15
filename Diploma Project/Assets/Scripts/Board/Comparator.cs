using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Comparator : Unit
{
    public List<Unit> inputs;
    public List<bool> types;

    public override void Tick()
    {
        output = 0;
        for (int i =0; i < inputs.Count; i++)
        {
            if (types[i])
                output += inputs[i].output;
            else
                output -= inputs[i].output;
        }
        if (Mathf.Abs(output) < 0.0001f)
            output = 0.0f;
    }

    private void Start()
    {
        Tick();
    }

}
