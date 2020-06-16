using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorScale : IndicatorEntity
{
    [SerializeField]
    Image scale;
    float coeff, min, max;

    public override void Perfome(float data)
    {
        scale.fillAmount = (data - min) / coeff;
    }

    public override void SpecStart()
    {
        Indicator indicator = GetComponent<Indicator>();
        min = indicator.min;
        max = indicator.max;
        coeff = max - min;
    }
}
