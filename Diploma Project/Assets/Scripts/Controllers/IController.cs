using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IController : ControlLaw
{
    [SerializeField]
    float integral = 0;

    public override float SetTask(float input)
    {
        integral += input * dt;
        return coefficient * integral;
    }
}
