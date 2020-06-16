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

    public override void PrepareToSim()
    {
        Source sourse = schemeObject.boardObject.GetComponent<Source>();
        sourse.GetComponent<BoxCollider>().enabled = false;
        Tuner t = sourse.GetComponentInChildren<Tuner>();
        t.min = sourse.min;
        t.max = sourse.max;
        t.GetDelta();
        t.enabled = true;
        t.GetComponent<CapsuleCollider>().enabled = true;
    }

    public override void PrepareToStop()
    {
        Source sourse = schemeObject.boardObject.GetComponent<Source>();
        sourse.GetComponent<BoxCollider>().enabled = true;
        Tuner t = sourse.GetComponentInChildren<Tuner>();
        t.enabled = false;
        t.GetComponent<CapsuleCollider>().enabled = false;
        sourse.inQueue = false;
    }

    public override void Save(BinaryWriter writer)
    {
        Source sourse = schemeObject.boardObject.GetComponent<Source>();
        sourse.Save(writer);
    }
}
