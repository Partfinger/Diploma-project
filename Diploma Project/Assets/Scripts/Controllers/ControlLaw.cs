using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControlLaw : MonoBehaviour
{
    public float coefficient;
    public static float dt;

    public abstract float SetTask(float input);
}
