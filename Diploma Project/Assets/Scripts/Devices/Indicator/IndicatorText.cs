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
        text.text = unit.output.ToString();
    }
}
