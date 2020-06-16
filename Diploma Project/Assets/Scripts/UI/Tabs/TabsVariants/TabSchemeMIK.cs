using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TabSchemeMIK : TabSchemeObject
{

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
        schemeObject.boardObject.GetComponent<MIK51>().enabled = true;
    }

    public override void PrepareToStop()
    {
        MIK51 controller = schemeObject.boardObject.GetComponent<MIK51>();
        controller.enabled = false;
        foreach(ControllerEntity entity in controller.controllers)
        {
            entity.inQueue = false;
        }
    }

    public override void Save(BinaryWriter writer)
    {
        throw new System.NotImplementedException();
    }
}
