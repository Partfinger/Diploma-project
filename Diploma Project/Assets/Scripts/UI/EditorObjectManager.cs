using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorObjectManager : MonoBehaviour
{
    public TabSchemeObject[] objects;
    public GameObject[] boardObjects, propPanels;
    public TabObjectGroup group;
    public Transform content, panelBoard, panelEditor;
    public Dropdown it;
    public EditorPanelManager panelManager;

    private void Start()
    {
        group.tabButtons = new List<TabButton>();
        TabSchemeObject.panelManager = panelManager;
    }

    public void AddNewObject(int index)
    {
        if (index > 0)
        {
            index--;
            try
            {
                TabSchemeObject newButton = Instantiate(objects[index], content);
                newButton.group = group;
                newButton.schemeObject.boardObject = Instantiate(boardObjects[index], panelBoard);
                newButton.schemeObject.propPanel = Instantiate(propPanels[index], panelEditor);
                newButton.schemeObject.propPanel.GetComponent<EditedPanel>().parent = newButton.schemeObject;
                newButton.schemeObject.propPanel.transform.SetAsLastSibling();
                group.Subscribe(newButton);
                group.OnTabSelected(newButton);
                it.SetValueWithoutNotify(0);
            }
            catch (NullReferenceException e)
            {
                Debug.LogError(e.Message + "\nCurrent index:" + index + "\n" + e.StackTrace);
            }
        }
    }

    public void RemoveElement()
    {
        group.active.Remove();
    }
}
