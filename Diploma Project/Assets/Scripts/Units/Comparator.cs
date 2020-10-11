using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Comparator : Unit, ISaveable, IOutput, IMultiInput, ITickable
{
    public List<IOutput> inputs = new List<IOutput>();
    public List<bool> types = new List<bool>();
    [SerializeField]
    float output;

    public List<IOutput> Inputs
    {
        get { return inputs; }
        set { inputs = value; }
    }

    public float Output { get { return output; } }

    public void Load(BinaryReader reader)
    {
        throw new System.NotImplementedException();
    }

    public void Save(BinaryWriter writer)
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
}
