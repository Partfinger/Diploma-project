using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public delegate void ReaderMethod(BinaryReader reader);

public class EditorObjectManager : MonoBehaviour
{
    public TabSchemeObject[] objects;
    public GameObject[] boardObjects, propPanels;
    public TabObjectGroup group;
    public Transform content, panelBoard, panelEditor;
    public Dropdown it;
    public Queue<int> loadIDs = new Queue<int>();

    public event ReaderMethod InputLoader;

    private void Start()
    {
        group.tabButtons = new List<TabButton>();
        DataClass.objectManager = this;
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
                newButton.EditorObjectID = index;
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

    public void Save(BinaryWriter writer)
    {
        writer.Write(DataClass.version);
        writer.Write(group.tabButtons.Count);
        for (int i = 0; i < group.tabButtons.Count; i++)
        {
            writer.Write(((TabSchemeObject)group.tabButtons[i]).EditorObjectID);
            ((TabSchemeObject)group.tabButtons[i]).Save(writer);
        }
    }

    public void Load(BinaryReader reader)
    {
        int version = reader.ReadInt32();
        if (version == DataClass.version)
        {
            int count = reader.ReadInt32();
            int index;
            for (int i = 0; i < count; i++)
            {
                index = reader.ReadInt32() + 1;
                AddNewObject(index);
                ((TabSchemeObject)group.active).Load(reader);
            }
        }
        InputLoader(reader);
    }
}
