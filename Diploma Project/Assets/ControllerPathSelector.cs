using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPathSelector : TabGroup
{
    public ControllerPathButton prefab;
    public Transform container;

    public override void OnTabSelected(TabItem item)
    {
        int id = tabItems.IndexOf((ControllerPathButton)item);
        Select(id);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        //MIKEditorPanel mep = DataClass.panelManager.captured.schemeObject.propPanel.GetComponent<MIKEditorPanel>();
        /*for (int i =0; i < mep.controlPaths.Count; i++)
        {
            ControllerPathButton btn = Instantiate(prefab, container);
            btn.group = this;
            Subscribe(btn);
            btn.GetComponentInChildren<Text>().text = i.ToString();
        }*/
    }

    public void Select(int id)
    {
        /*if (id > -1)
        {
            DataClass.panelManager.AddInput(id);
        }
        Cancle();*/
    }

    public void Cancle()
    {
        for (int i = 0; i < tabItems.Count; i++)
        {
            Destroy(tabItems[i].gameObject);
        }
        tabItems.Clear();
        gameObject.SetActive(false);
        DataClass.panelManager.CancleSelector();
    }

    public override void Remove(TabItem item)
    {
        throw new System.NotImplementedException();
    }
}
