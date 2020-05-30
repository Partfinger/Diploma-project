using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorObjectManager : MonoBehaviour
{
    public EditorElement[] items;
    public GameObject[] onSchemeElements;
    public EditorPanel[] panels;
    List<EditorElement> elements;
    public Transform content, container, panelEditor;
    public Dropdown it;
    [SerializeField]
    public EditorElement current;

    private void Start()
    {
        elements = new List<EditorElement>();
        EditorElement.container = container;
        EditorElement.panelUI = panelEditor;
        EditorElement.manager = this;
    }

    public void AddNewObject(int index)
    {
        if (index > 0)
        {
            index--;
            EditorElement newElement = Instantiate(items[index], content);
            GameObject subject = Instantiate(onSchemeElements[index], container);
            EditorPanel panel = Instantiate(panels[index], panelEditor);
            newElement.panel = panel;
            panel.SetParent(ref newElement);
            newElement.subject = subject;
            elements.Add(newElement);
            newElement.Init(ref subject);
            //current = newElement;
            //current.panel.Show();
            it.SetValueWithoutNotify(0);
            //current.GetComponent<Button>().Select();
        }
    }

    public void Hide()
    {
        current.panel.Hide();
        current = null;
    }
}
