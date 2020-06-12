using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPath : TabSchemeObject
{
    public int ID;
    TabSchemeObject input;
    public TabSchemeObject Input
    {
        get
        {
            return input;
        }
        set
        {
            input = value;
            entity.input = input.schemeObject.boardObject.GetComponent<Unit>();
        }
    }
    public MIKEditorPanel panel;
    public Transform container;
    public LawEditor lawPrefab;
    public Text idText, inputText;
    public List<LawEditor> laws;
    public ControllerEntity entity;

    private void Start()
    {
        laws = new List<LawEditor>();
    }

    public void Delete()
    {
        panel.RemoveItem(ID);
        Destroy(gameObject);
    }

    public void SetInput()
    {

    }

    internal void RemoveAt(int iD)
    {
        laws.RemoveAt(iD);
        entity.laws.RemoveAt(iD);
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
        //(ControlLaw)Activator.CreateInstance(GetTypeLaw(lawID))
        entity.laws.Add(
            (ControlLaw)Activator.CreateInstance(
                panel.GetTypeLaw(0)));
        entity.laws[le.ID].coefficient = le.coef;
    }
}
