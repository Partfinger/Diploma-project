using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerLaw : MonoBehaviour, ITunable
{
    public float coefficient;
    public static float dt;

    public abstract float SetTask(float input);

    public void Tune(float tune)
    {
        coefficient = tune;
    }
}
