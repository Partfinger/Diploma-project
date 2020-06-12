using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class ControlLaw
{
    public float coefficient;
    public static float dt;

    public abstract float SetTask(float input);
}
