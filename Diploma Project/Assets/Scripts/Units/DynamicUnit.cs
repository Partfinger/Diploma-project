using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DynamicUnit : Unit, ISaveable, IOutputable, IInputable, ITickable, ISimulatable
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

    public override void Load(BinaryReader reader)
    {
        Name = reader.ReadString();
        function.Load(reader);
    }

    public override void Save(BinaryWriter writer)
    {
        writer.Write(Name);
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

    public override void Validate(List<string> logger)
    {
        if (Input == null)
            logger.Add($"Не призначений вхід для {Name}");
        if (function.numerator.Length == 0 || function.denumerator.Length == 0)
            logger.Add($"Не повністю задані параметри для {Name}");
    }
}
