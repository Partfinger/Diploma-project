using StateEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabDisplayInputsGroup : TabGroup, IColorSetable
{
    public TabDisplayInput inputPrefab;
    public Transform content;
    public DisplayEditor editor;
    public RectTransform rect;
    [SerializeField]
    public static EditorProvider editorProvider;

    internal void Show(Display _display)
    {
        if (editor.display)
        {
            if (editor.display != _display)
            {
                RemoveTabs();
            }
            else
            {
                return;
            }
        }
        editor.display = _display;
        for (int i = 0; i < editor.display.inputs.Count; i++)
        {
            AddPrefab();
            UpdateData(i);
        }
    }

    private void UpdateData(int index)
    {
        TabDisplayInput input = (TabDisplayInput)tabItems[index];
        if (editor.display.inputs[index] != null)
            input.SetInput(((Unit)editor.display.inputs[index]).Name);
        input.SetColor(editor.display.drawers[index].color);
    }

    private void AddPrefab()
    {
        TabDisplayInput input = Instantiate(inputPrefab, transform);
        input.group = this;
        tabItems.Add(input);

        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
    }

    public void Add()
    {
        TabDisplayInput input = Instantiate(inputPrefab, content);
        input.group = this;
        tabItems.Add(input);
        editor.display.AddNew();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
    }

    public void CallColorPicker(TabDisplayInput item)
    {
        active = item;
        editorProvider.colorSetable = this;
        editorProvider.ShowColorPicker(item.color);
    }

    public void SetInput(TabDisplayInput item, TabObject tabObject)
    {
        int index = tabItems.IndexOf(item);
        editor.display.inputs[index] = ((IOutput)tabObject.unit);
    }

    public override void Remove(TabItem item)
    {
        throw new System.NotImplementedException();
    }

    public void SetColor(Color color)
    {
        editor.display.drawers[tabItems.IndexOf(active)].color = color;
        ((TabDisplayInput)active).SetColor(color);
    }
}
