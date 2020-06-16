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
        schemeObject.boardObject.transform.localPosition = new Vector3(reader.ReadSingle(), reader.ReadSingle(), 0);
    }

    public override void LoadInputs(BinaryReader reader)
    {
        schemeObject.Input =
            ((TabSchemeObject)DataClass.objectManager.group.tabButtons[
                DataClass.objectManager.loadIDs.Dequeue()
                ]).schemeObject;
    }

    public override void PrepareToSim()
    {
        Indicator indicator = (Indicator)schemeObject.boardObject.GetComponent<EntryUnit>();
        indicator.indicators[0].SpecStart();
        indicator.indicators[1].SpecStart();
        indicator.GetComponent<BoxCollider>().enabled = false;
    }

    public override void PrepareToStop()
    {
        schemeObject.boardObject.GetComponent<BoxCollider>().enabled = true;
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
        writer.Write(schemeObject.boardObject.transform.localPosition.x);
        writer.Write(schemeObject.boardObject.transform.localPosition.y);
    }
}
