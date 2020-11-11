using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using UnityEngine;

public class Comparator : Unit, IOutputable, IMultiInput, ITickable
{
    public List<IOutputable> inputs = new List<IOutputable>();
    public List<bool> types = new List<bool>();
    [SerializeField]
    float output;

    public List<IOutputable> Inputs
    {
        get { return inputs; }
        set { inputs = value; }
    }

    public float Output { get { return output; } set { output = value; } }

    public override void Load(BinaryReader reader)
    {
        throw new System.NotImplementedException();
    }

    public override void Save(BinaryWriter writer)
    {
        throw new System.NotImplementedException();
    }

    public void Tick()
    {
        output = 0;
        for (int i = 0; i < inputs.Count; i++)
        {
            if (types[i])
                output += inputs[i].Output;
            else
                output -= inputs[i].Output;
        }
    }

    public override void Validate(List<string> logger)
    {
        for (int index = 0; index < inputs.Count; index++)
            if (inputs[index] == null)
                logger.Add($"Не призначений вхід №{index} для {Name}");
    }
}
