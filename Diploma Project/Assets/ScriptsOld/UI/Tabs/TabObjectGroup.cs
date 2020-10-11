using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TabObjectGroup : TabGroup
{
    public void Save(BinaryWriter writer)
    {
        foreach (TabSchemeObject tab in tabItems)
        {
            tab.Save(writer);
        }
    }

    public void Load(BinaryReader reader)
    {
        foreach (TabSchemeObject tab in tabItems)
        {
            tab.Load(reader);
        }
    }

    public override void Remove(TabItem item)
    {
        throw new System.NotImplementedException();
    }
}
