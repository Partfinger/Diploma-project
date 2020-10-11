using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class LawEditor : MonoBehaviour
{
    public ControlPath path;
    public int ID, lawID;
    public float coef;

    public void SetType(int n)
    {
        if (lawID != n)
        {
            lawID = (byte)n;
            UpdateData();
        }    
    }

    public void SetCoef(string str)
    {
        if (str.Length > 0)
        {
            coef = float.Parse(Regex.Replace(str, "\\.", ","));
            UpdateData();
        }
    }

    public void UpdateData()
    {
        path.panel.UpdateData(path.ID, ID, lawID, coef);
    }

    public void Remove()
    {
        path.RemoveAt(ID);
        Destroy(gameObject);
    }

    internal void Save(BinaryWriter writer)
    {
        writer.Write(ID);
        writer.Write(lawID);
        writer.Write(coef);
    }

    internal void Load(BinaryReader reader)
    {
        ID = reader.ReadInt32();
        lawID = reader.ReadInt32();
        coef = reader.ReadSingle();
        UpdateData();
    }
}
