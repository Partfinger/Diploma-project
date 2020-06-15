using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIKEditorPanel : EditedPanel
{
    public ControlPath prefab;
    public Transform container;
    public ControllerEntity ePrefab;
    public List<ControlPath> controlPaths;
    public ControlLaw[] laws;

    private void Start()
    {
        controlPaths = new List<ControlPath>();
    }

    public void RemoveItem(int id)
    {
        controlPaths.RemoveAt(id);
        parent.boardObject.GetComponent<MIK51>().controllers.RemoveAt(id);
        for (int i=0; i < controlPaths.Count; i++)
        {
            controlPaths[i].UpdateID(i);
        }
    }

    internal void UpdateData(int iD1, int iD2, int lawID, float coef)
    {
        ControllerEntity ce = parent.boardObject.GetComponent<MIK51>().controllers[iD1];
        if (lawID != GetTypeLawInt(ce.laws[iD2].GetType().Name))
        {
            ce.laws[iD2] = (ControlLaw)Activator.CreateInstance(GetTypeLaw(lawID));
        }
        ce.laws[iD2].coefficient = coef;
    }

    public override void AddInput(GameObject dropZone)
    {
        ControlPath cp =
            dropZone.GetComponentInParent<ControlPath>();
        cp.schemeObject.Input = DataClass.panelManager.captured.schemeObject;
        cp.inputText.text = cp.schemeObject.Input.name;
    }

    public int GetTypeLawInt(string n)
    {
        switch (n)
        {
            case "PController":
                return 0;
            case "IController":
                return 1;
            case "DController":
                return 2;
        }
        return -1;
    }

    public Type GetTypeLaw(int i)
    {
        string n = "Object";
        switch (i)
        {
            case 0:
                n = "PController";
                break;
            case 1:
                n = "IController";
                break;
            case 2:
                n = "DController";
                break;
        }
        return Type.GetType(n);
    }

    public void AddNewPath()
    {
        ControlPath p = Instantiate(prefab, container);
        p.panel = this;
        controlPaths.Add(p);
        p.UpdateID(controlPaths.Count - 1);
        ControllerEntity entity = Instantiate(ePrefab, parent.boardObject.transform);
        p.schemeObject.boardObject = entity.gameObject;
        parent.boardObject.GetComponent<MIK51>().controllers.Add(entity);
    }
}
