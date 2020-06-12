using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorText : IndicatorEntity
{
    [SerializeField]
    Text text;

    public override void Perfome(ref float data)
    {
        text.text = string.Format("{0:0.0}", data);
    }
}
