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
    Type[] controllerTypes =
    {
        typeof(PController),
        typeof(IController),
        typeof(DController)
    };

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
        if (lawID != GetTypeLawInt(ce.laws[iD2].GetType()))
        {
            ce.laws[iD2] = (ControlLaw)ce.gameObject.AddComponent(GetTypeLaw(lawID));
        }
        ce.laws[iD2].coefficient = coef;
    }

    public override void AddInput(GameObject dropZone)
    {
        //ControlPath cp =
        //    dropZone.GetComponentInParent<ControlPath>();
        //cp.schemeObject.Input = DataClass.panelManager.captured.schemeObject;
       // cp.inputText.text = cp.schemeObject.Input.name;
    }

    public int GetTypeLawInt(Type type)
    {
        for (int i= 0; i < 3; i++)
        {
            if (type == controllerTypes[i])
                return i;
        }
        return -1;
    }

    public Type GetTypeLaw(int i)
    {
        return controllerTypes[i];
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

    public override void Refresh()
    {
        throw new NotImplementedException();
    }
}
