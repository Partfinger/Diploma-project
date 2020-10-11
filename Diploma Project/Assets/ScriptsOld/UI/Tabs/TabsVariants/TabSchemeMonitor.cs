using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TabSchemeMonitor : TabSchemeObject
{
    public override void GetName()
    {
        title.text = Name;
    }

    public override void Load(BinaryReader reader)
    {
        throw new System.NotImplementedException();
    }

    public override void LoadInputs(BinaryReader reader)
    {
        throw new System.NotImplementedException();
    }

    public override void PrepareToSim()
    {
        Outflow outflow = schemeObject.boardObject.GetComponent<Outflow>();
        if (!DataClass.objectManager.wasSimulation)
        {
            outflow.enabled = true;
            DataClass.objectManager.wasSimulation = true;
        }
        else
        {
            outflow.Start();
        }
    }

    public override void PrepareToStop()
    {
        Outflow outflow = schemeObject.boardObject.GetComponent<Outflow>();
        outflow.StopSim();
    }

    public override void Save(BinaryWriter writer)
    {
        throw new System.NotImplementedException();
    }
}
