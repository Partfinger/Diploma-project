using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ControlPath : TabSchemeObject
{
    public new int ID;
    public MIKEditorPanel panel;
    public Transform container;
    public LawEditor lawPrefab;
    public Text idText, inputText;
    public List<LawEditor> laws = new List<LawEditor>();

    public void Delete()
    {
        panel.RemoveItem(ID);
        Destroy(gameObject);
    }

    internal void RemoveAt(int iD)
    {
        laws.RemoveAt(iD);
        schemeObject.boardObject.GetComponent<ControllerEntity>().laws.RemoveAt(iD);
        for (int i =0; i < laws.Count; i++)
        {
            laws[i].ID = i;
        }
    }

    internal void UpdateID(int i)
    {
        if (i != ID)
        {
            ID = i;
            idText.text = ID.ToString();
        }
    }

    public void AddLaw()
    {
        LawEditor le = Instantiate(lawPrefab, container);
        le.path = this;
        laws.Add(le);
        le.ID = laws.IndexOf(le);
        ControllerEntity ce = schemeObject.boardObject.GetComponent<ControllerEntity>();
        PController con =  (PController)ce.gameObject.AddComponent(typeof(PController));
        con.coefficient = 1;
        ce.laws.Add(con);
    }

    public override void GetName()
    {
        title.text = Name + " " + ID;
    }

    public override void Save(BinaryWriter writer)
    {
        writer.Write(laws.Count);
        foreach (LawEditor law in laws)
        {
            law.Save(writer);
        }
        writer.Write(HasInputs());
        if (HasInputs())
        {
            writer.Write(GetIDInput());
        }
    }

    public override void Load(BinaryReader reader)
    {
        int num = reader.ReadInt32();
        for (int i = 0; i < num; i++)
        {
            AddLaw();
            laws[i].Load(reader);
        }
        if (reader.ReadBoolean())
        {
            DataClass.objectManager.InputLoader += LoadInputs;
        }
    }

    public override void LoadInputs(BinaryReader reader)
    {
        throw new NotImplementedException();
    }
}
