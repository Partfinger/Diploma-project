using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TabSchemeBRY : TabSchemeObject
{
    public override void GetName()
    {
        title.text = Name + " " + ID;
    }

    public override void Load(BinaryReader reader)
    {
        Source sourse = schemeObject.boardObject.GetComponent<Source>();
        sourse.Load(reader);
    }

    public override void LoadInputs(BinaryReader reader)
    {
        return;
    }

    public override void Save(BinaryWriter writer)
    {
        Source sourse = schemeObject.boardObject.GetComponent<Source>();
        sourse.Save(writer);
    }
}
