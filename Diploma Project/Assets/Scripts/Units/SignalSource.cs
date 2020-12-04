using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SignalSource : Unit, IOutputable, IMinMax, IStartValue, ISaveable, ITunable, ISimulatable
{
    [SerializeField]
    float output, min, max, start;
    public float Output { get => output; set { output = value; } }
    public float Min 
    {
        get { return min; }
        set { min = value; }
    }
    public float Max 
    {
        get { return max; }
        set { max = value; }
    }
    public float Start 
    {
        get { return start; }
        set { start = value; }
    }

    public void Tune(float control)
    {
        output = control;
    }

    public override void Load(BinaryReader reader)
    {
        Name = reader.ReadString();
        min = reader.ReadSingle();
        max = reader.ReadSingle();
        start = reader.ReadSingle();
        transform.localPosition = new Vector3(reader.ReadSingle(), reader.ReadSingle(), 0);
    }

    public override void Save(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(min);
        writer.Write(max);
        writer.Write(start);
        writer.Write(transform.localPosition.x);
        writer.Write(transform.localPosition.y);
    }

    public void StartSimulation()
    {
        GetComponent<Collider>().enabled = false;
    }

    public void StopSimulation()
    {
        GetComponent<Collider>().enabled = true;
    }

    public override void Validate(List<string> logger)
    {
        if (max < min)
        {
            logger.Add($"Для {Name} значення max менше ніж min!");
        }
        else if (max == min)
        {
            logger.Add($"Для {Name} min і max мають однакові значення!");
        }

        if (start > max || start < min)
        {
            logger.Add($"Для {Name} стартове значення виходить за межу допустимих значень!");
        }
    }
}
