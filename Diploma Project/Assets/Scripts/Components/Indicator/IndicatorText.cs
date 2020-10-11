using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorText : Indicator
{
    [SerializeField]
    Text text;

    public override void Prepare()
    {
        return;
    }

    public override void Set(float data)
    {
        text.text = data.ToString("0.##");
    }
}
