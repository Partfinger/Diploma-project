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
        subject.inputs.Add(null);
        newO.image.color = subject.colors[inputs.Count];
        inputs.Add(newO);
        //subject.colors.Add(Color.black);
    }

    internal void Remove(MonitorInput monitorInput)
    {
        int index = inputs.IndexOf(monitorInput);
        subject.inputs.RemoveAt(index);
        //subject.colors.RemoveAt(index);
    }

    public void AddInput(int id)
    {
        subject.inputs[id] = DataClass.panelManager.captured.schemeObject.boardObject.GetComponent<Unit>();
        //subject.colors[id] = inputs[id].color;
    }

    public override void AddInput(GameObject dropZone)
    {
        foreach (MonitorInput tab in inputs)
        {
            if (tab.gameObject == dropZone)
            {
                tab.Input = DataClass.panelManager.captured.schemeObject;
                if (DataClass.panelManager.itIsController)
                    tab.text.text = DataClass.panelManager.captured.gameObject.name;
                else
                    tab.text.text = DataClass.panelManager.captured.title.text;
                AddInput(inputs.IndexOf(tab));
                break;
            }
        }
    }

    public override void Refresh()
    {
        throw new NotImplementedException();
    }
}
