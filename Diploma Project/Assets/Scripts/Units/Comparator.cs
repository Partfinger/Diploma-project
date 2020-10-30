using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using UnityEngine;

public class Comparator : Unit, ISaveable, IOutputable, IMultiInput, ITickable
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
