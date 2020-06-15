using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TabSchemeTransferFunction : TabSchemeObject
{
    public static new int ID = 0;

    public override void GetName()
    {
        title.text = Name + " " + ID;
    }

    public override void Load(BinaryReader reader)
    {
        DUnit unit = schemeObject.boardObject.GetComponent<DUnit>();
        if (!reader.ReadBoolean())
        {
            unit.gameObject.AddComponent<ZForm>();
        }
        unit.funct.Load(reader);
        if (reader.ReadBoolean())
        {
            DataClass.objectManager.InputLoader += LoadInputs;
            DataClass.objectManager.loadIDs.Enqueue(reader.ReadInt32());
        }
    }

    public override void LoadInputs(BinaryReader reader)
    {
        schemeObject.Input = DataClass.objectManager.objects[DataClass.objectManager.loadIDs.Dequeue()].schemeObject;
    }

    public override void Save(BinaryWriter writer)
    {
        DUnit unit = schemeObject.boardObject.GetComponent<DUnit>();
        writer.Write(unit.funct is SForm);
        unit.funct.Save(writer);
        writer.Write(schemeObject.Input != null);
        if (schemeObject.Input != null)
        {
            writer.Write(GetIDInput());
        }
    }
}
