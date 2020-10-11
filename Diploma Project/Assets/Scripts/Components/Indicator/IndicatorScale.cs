using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorScale : Indicator
{
    [SerializeField]
    Image scale;
    float delta;
    IMinMax subject;

    public override void Prepare()
    {
        delta = subject.Max - subject.Min;
    }

    public override void Set(float data)
    {
        scale.fillAmount = (data - subject.Min) / delta;
    }

    void Start()
    {
        subject = GetComponentInParent<IMinMax>();
        delta = subject.Max - subject.Min;
    }
}
