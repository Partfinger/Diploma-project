using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TabSchemeComparator : TabSchemeObject
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
        schemeObject.boardObject.SetActive(true);
    }

    public override void PrepareToStop()
    {
        schemeObject.boardObject.SetActive(false);
        //schemeObject.boardObject.GetComponent<Comparator>().inQueue = false;
    }

    public override void Save(BinaryWriter writer)
    {
        /*Comparator comparator = schemeObject.boardObject.GetComponent<Comparator>();
        writer.Write(comparator.inputs.Count);
        for (int i = 0; i < comparator.inputs.Count; i++)
        {
            if (comparator.inputs[i])
            {
                throw new System.NotImplementedException();
            }
        }*/
    }
}
