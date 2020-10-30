﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DynamicUnit : Unit, ISaveable, IOutputable, IInputable, ITickable, IMovable
{
    public TransferFunction function;
    [SerializeField]
    float output;

    public float Output
    {
        get
        {
            return output;
        }
        set
        {
            output = value;
        }
    }

    public IOutputable Input { get; set; }

    public void Load(BinaryReader reader)
    {
        function.Load(reader);
    }

    public void Save(BinaryWriter writer)
    {
        function.Save(writer);
    }

    public void StartSimulation()
    {
        output = function.FirstTransform(0);
    }

    public void StopSimulation()
    {
        return;
    }

    public void Tick()
    {
        output = function.Transform(Input.Output);
    }
}
