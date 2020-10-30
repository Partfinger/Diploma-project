using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomaizer : Unit, IMinMax, IOutputable, ITickable
{
    float output;

    public float Min { get; set; }
    public float Max { get; set; }
    public float Output { get { return output; } set { output = value; } }

    public void Tick()
    {
        output = Random.Range(Min, Max);
    }
}
