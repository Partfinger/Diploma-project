using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorScale : Indicator
{
    [SerializeField]
    Image scale;
    float coeff;

    private void Start()
    {
        coeff = max - min;
    }


    private void Update()
    {
        scale.fillAmount = (unit.output - min) / coeff;
    }
}
