using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IndicatorEntity : MonoBehaviour
{
    public abstract void SpecStart();

    public abstract void Perfome(float data);
}
