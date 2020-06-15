using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TabObjectGroup : TabGroup
{
    public void Save(BinaryWriter writer)
    {
        foreach (TabSchemeObject tab in tabButtons)
        {
            tab.Save(writer);
        }
    }

    public void Load(BinaryReader reader)
    {
        foreach (TabSchemeObject tab in tabButtons)
        {
            tab.Load(reader);
        }
    }
}
