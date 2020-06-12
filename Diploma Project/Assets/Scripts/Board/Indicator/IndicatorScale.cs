using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorScale : IndicatorEntity
{
    [SerializeField]
    Image scale;
    float coeff, min, max;

    private void Start()
    {
        Indicator indicator = GetComponent<Indicator>();
        min = indicator.min;
        max = indicator.max;
        coeff = max - min;
    }

    public override void Perfome(ref float data)
    {
        scale.fillAmount = (data - min) / coeff;
    }
}
