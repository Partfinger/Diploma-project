using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Constant : Unit, IStartValue, IOutputable
{
    float output = 0;
    public float Output { get { return output; } set { output = value; } }
    float IStartValue.Start { get { return output; } set { output = value; } }

    public override void Load(BinaryReader reader)
    {
        throw new System.NotImplementedException();
    }

    public override void Save(BinaryWriter writer)
    {
        throw new System.NotImplementedException();
    }

    public override void Validate(List<string> logger)
    {
        if (output == 0)
            logger.Add($"{Name} має значення значення за замовчуванням!");
    }
}
