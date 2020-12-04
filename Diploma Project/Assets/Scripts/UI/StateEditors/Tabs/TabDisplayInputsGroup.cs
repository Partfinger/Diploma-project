using StateEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabDisplayInputsGroup : TabInputsGroup, IColorSetable
{
    public static EditorProvider editorProvider;
    Display display;

    public override void Show(Unit _display)
    {
        subject = _display as IMultiInput;
        if (display == _display as Display)
        {
            return;
        }
        RemoveTabs();
        display = _display as Display;
        for (int i = 0; i < display.Inputs.Count; i++)
        {
            AddPrefab();
            UpdateData(i);
        }
    }

    protected override void UpdateData(int index)
    {
        TabDisplayInput input = (TabDisplayInput)tabItems[index];
        if (display.Inputs[index] != null)
            input.SetInput(((Unit)display.Inputs[index]).Name);
        input.SetColor(display.drawers[index].color);
    }

    public override void Add()
    {
        base.AddPrefab();
        display.AddNew();
    }

    public void CallColorPicker(TabDisplayInput item)
    {
        active = item;
        editorProvider.colorSetable = this;
        editorProvider.ShowColorPicker(item.color);
    }

    public override void Remove(TabItem item)
    {
        int index = tabItems.IndexOf(item);
        display.Inputs.RemoveAt(index);
        Destroy(display.drawers[index]);
        display.drawers.RemoveAt(index);
        tabItems.RemoveAt(index);
    }

    public void SetColor(Color color)
    {
        display.drawers[tabItems.IndexOf(active)].color = color;
        ((TabDisplayInput)active).SetColor(color);
    }
}
