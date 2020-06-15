using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    public void Save(BinaryWriter writer)
    {
        writer.Write(min);
        writer.Write(max);
        writer.Write(start);
    }

    public void Load(BinaryReader reader)
    {
        min = reader.ReadSingle();
        max = reader.ReadSingle();
        start = reader.ReadSingle();
    }
}
