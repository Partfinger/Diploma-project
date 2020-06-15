using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TabSchemeI11 : TabSchemeObject
{
    public override void GetName()
    {
        title.text = Name;
    }

    public override void Load(BinaryReader reader)
    {
        Indicator indicator = (Indicator)schemeObject.boardObject.GetComponent<Unit>();
        indicator.max = reader.ReadSingle();
        indicator.min = reader.ReadSingle();
        if (reader.ReadBoolean())
        {
            DataClass.objectManager.loadIDs.Enqueue(reader.ReadInt32());
            DataClass.objectManager.InputLoader += LoadInputs;
        }
    }

    public override void LoadInputs(BinaryReader reader)
    {
        schemeObject.Input = DataClass.objectManager.objects[DataClass.objectManager.loadIDs.Dequeue()].schemeObject;
    }

    public override void Save(BinaryWriter writer)
    {
        Indicator indicator = (Indicator)schemeObject.boardObject.GetComponent<Unit>();
        writer.Write(indicator.max);
        writer.Write(indicator.min);
        writer.Write(HasInputs());
        if (HasInputs())
        {
            writer.Write(GetIDInput());
        }
    }
}
