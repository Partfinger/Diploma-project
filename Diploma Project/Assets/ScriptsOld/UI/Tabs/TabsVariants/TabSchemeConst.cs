using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TabSchemeConst : TabSchemeObject
{
    public override void GetName()
    {
        title.text = Name;
    }

    public override void Load(BinaryReader reader)
    {
        schemeObject.boardObject.GetComponent<Constant>()._const = reader.ReadSingle();
    }

    public override void LoadInputs(BinaryReader reader)
    {
        return;
    }

    public override void PrepareToSim()
    {
        Constant c = schemeObject.boardObject.GetComponent<Constant>();
        c.output = c._const;
    }

    public override void PrepareToStop()
    {
        return;
    }

    public override void Save(BinaryWriter writer)
    {
        writer.Write(schemeObject.boardObject.GetComponent<Constant>()._const);
    }
}
