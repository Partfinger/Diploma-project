using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Randomaizer : Unit, IMinMax, IOutputable, ITickable
{
    float output;

    public float Min { get; set; }
    public float Max { get; set; }
    public float Output { get { return output; } set { output = value; } }

    public override void Load(BinaryReader reader)
    {
        Name = reader.ReadString();
        Min = reader.ReadSingle();
        Max = reader.ReadSingle();
    }

    public override void Save(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(Min);
        writer.Write(Max);
    }

    public void Tick()
    {
        output = Random.Range(Min, Max);
    }

    public override void Validate(List<string> logger)
    {
        if (Max < Min)
        {
            logger.Add($"Для {Name} значення max менше ніж min!");
        }
        else if (Max == Min)
        {
            logger.Add($"Для {Name} min і max мають однакові значення!");
        }
    }
}
