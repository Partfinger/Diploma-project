using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorText : Indicator
{
    [SerializeField]
    Text text;

    private void Update()
    {
        text.text = string.Format("{0:0.0}", unit.output);
    }
}
