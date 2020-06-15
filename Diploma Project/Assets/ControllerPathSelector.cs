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
        Select(id);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        MIKEditorPanel mep = DataClass.panelManager.captured.schemeObject.propPanel.GetComponent<MIKEditorPanel>();
        for (int i =0; i < mep.controlPaths.Count; i++)
        {
            ControllerPathButton btn = Instantiate(prefab, container);
            btn.group = this;
            Subscribe(btn);
            btn.name = i.ToString();
        }
    }

    public void Select(int id)
    {
        Debug.Log(id);
        Cancle();
    }

    public void Cancle()
    {
        for (int i = 0; i < tabButtons.Count; i++)
        {
            Unsubscribe(tabButtons[i]);
        }
        tabButtons.Clear();
        gameObject.SetActive(false);
        DataClass.panelManager.CancleSelector();
    }
}
