using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : Unit, IStartValue, IOutputable
{
    float output;
    public float Output { get { return output; } set { output = value; } }
    float IStartValue.Start { get { return output; } set { output = value; } }
}
