using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Comparator : EntryUnit
{
    public EntryUnit[] anothers;
    public bool[] types;

    public override void Tick()
    {
        output = input.output;
        for (int i =0; i < anothers.Length; i++)
        {
            output += types[i] ? anothers[i].output : -anothers[i].output;
        }
        if (Mathf.Abs(output) < 0.0001f)
            output = 0.0f;
    }

    private void Start()
    {
        Tick();
    }

}
