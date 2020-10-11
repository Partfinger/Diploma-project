using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DController : ControlLaw
{
    [SerializeField]
    float oldInput = 0;

    public override float SetTask(float input)
    {
        float result = (input - oldInput) / dt;
        oldInput = input;
        return result;
    }
}
