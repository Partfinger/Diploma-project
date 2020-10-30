using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : ControllerLaw
{
    public override float SetTask(float input)
    {
        return input * coefficient;
    }
}
