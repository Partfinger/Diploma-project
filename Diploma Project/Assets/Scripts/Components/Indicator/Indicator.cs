using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Indicator : MonoBehaviour
{
    public abstract void Set(float data);

    public abstract void Prepare();
}
