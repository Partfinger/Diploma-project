using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPathSelector : TabGroup
{
    public ControllerPathButton prefab;
    public Transform container;

    public override void OnTabSelected(TabButton button)
    {
        int id = tabButtons.IndexOf((ControllerPathButton)button);
        Debug.Log(id);
    }

    public void Show()
    {
        MIKEditorPanel mep = DataClass.panelManager.captured.schemeObject.propPanel.GetComponent<MIKEditorPanel>();
        for (int i =0; i < mep.controlPaths.Count; i++)
        {
            ControllerPathButton btn = Instantiate(prefab, container);
            Subscribe(btn);
            btn.name = i.ToString();
        }
    }

    public void Select(int id)
    {

    }

    public void Cancle()
    {

    }
}
