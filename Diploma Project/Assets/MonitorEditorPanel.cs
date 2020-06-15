using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorEditorPanel : EditedPanel
{
    public MonitorInput prefab;
    public Transform content;
    public Outflow subject;
    List<MonitorInput> inputs;

    private void Start()
    {
        subject = parent.boardObject.GetComponent<Outflow>();
        inputs = new List<MonitorInput>();
    }

    public void Add()
    {
        MonitorInput newO = Instantiate(prefab, content);
        newO.panel = this;
        newO.transform.SetAsLastSibling();
        inputs.Add(newO); 
        subject.inputs.Add(null);
        subject.colors.Add(Color.black);
    }

    internal void Remove(MonitorInput monitorInput)
    {
        int index = inputs.IndexOf(monitorInput);
        subject.inputs.RemoveAt(index);
        subject.colors.RemoveAt(index);
    }

    public void AddInput(int id)
    {
        subject.inputs[id] = DataClass.panelManager.captured.schemeObject.boardObject.GetComponent<Unit>();
        Color c = Color.red;
        c.a = 1;
        subject.colors[id] = inputs[id].color;
    }

    public override void AddInput(GameObject dropZone)
    {
        foreach (MonitorInput tab in inputs)
        {
            if (tab.gameObject == dropZone)
            {
                tab.Input = DataClass.panelManager.captured.schemeObject;
                AddInput(inputs.IndexOf(tab));
                break;
            }
        }
    }
}
