using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Adapter : Unit, IMultiInput, ITickable, IOutputable, ISaveable
{
    List<IOutputable> inputs = new List<IOutputable>();
    public List<IOutputable> Inputs { get { return inputs; } set { inputs = value; } }

    float output;
    public float Output { get { return output; } set { output = value; } }

    public List<float> WeightCoefficient;

    public void Tick()
    {
        output = 0;
        for (int i = 0; i < Inputs.Count; i++)
        {
            output += inputs[i].Output * WeightCoefficient[i];
        }
    }

    public void Save(BinaryWriter writer)
    {
        throw new System.NotImplementedException();
    }

    public void Load(BinaryReader reader)
    {
        throw new System.NotImplementedException();
    }

    public override void Validate(List<string> logger)
    {
        for (int index = 0; index < inputs.Count; index++)
        {
            if (inputs[index] == null)
                logger.Add($"Не призначений вхід №{index} для {Name}");
        }
    }
}
