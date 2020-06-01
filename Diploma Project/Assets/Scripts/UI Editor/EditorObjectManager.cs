using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorObjectManager : MonoBehaviour
{
    public TabButton[] objects;
    public GameObject[] boardObjects, propPanels;
    public TabGroup group;
    public Transform content, panelBoard, panelEditor;
    public Dropdown it;
    public EditorPanelManager panelManager;

    private void Start()
    {
        group.tabButtons = new List<TabButton>();
        TabButton.panelManager = panelManager;
    }

    public void AddNewObject(int index)
    {
        if (index > 0)
        {
            index--;
            TabButton newButton = Instantiate(objects[index], content);
            newButton.group = group;
            newButton.schemeObject.boardObject = Instantiate(boardObjects[index], panelBoard);
            newButton.schemeObject.propPanel = Instantiate(propPanels[index], panelEditor);
            newButton.schemeObject.propPanel.GetComponent<EditedPanel>().parent = newButton.schemeObject;
            newButton.schemeObject.propPanel.transform.SetSiblingIndex(2);
            group.OnTabSelected(newButton);
            it.SetValueWithoutNotify(0);
        }
    }

    public void RemoveElement()
    {
        group.active.Remove();
    }
}
