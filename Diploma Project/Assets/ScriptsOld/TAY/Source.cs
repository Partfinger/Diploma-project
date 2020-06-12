using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : Unit
{
    public float min, max, start;

    public IndicatorText indicatorText;

    private void Start()
    {
        UpdatePanel();
    }

    public void UpdatePanel()
    {
        indicatorText.Perfome(ref start);
    }

    public override void Tick()
    {
        return;
    }
}
