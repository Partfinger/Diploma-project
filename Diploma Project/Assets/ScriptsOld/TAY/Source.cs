using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Source : Unit
{
    public float min, max, start;

    public IndicatorText indicatorText;

    public void UpdatePanel()
    {
        indicatorText.Perfome(start);
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
        writer.Write(transform.localPosition.x);
        writer.Write(transform.localPosition.y);
    }

    public void Load(BinaryReader reader)
    {
        min = reader.ReadSingle();
        max = reader.ReadSingle();
        start = reader.ReadSingle();
        transform.localPosition = new Vector3(reader.ReadSingle(), reader.ReadSingle(), 0);
    }
}
