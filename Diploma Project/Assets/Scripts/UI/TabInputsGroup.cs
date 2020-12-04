using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TabInputsGroup : TabGroup
{
    public TabItem inputPrefab;
    public RectTransform rect;
    protected IMultiInput subject;

    protected virtual void AddPrefab()
    {
        TabItem input = Instantiate(inputPrefab, transform);
        input.group = this;
        tabItems.Add(input);
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
    }

    public void SetInput(TabItem item, TabObject tabObject)
    {
        int index = tabItems.IndexOf(item);
        if (tabObject.unit is IOutputable)
            subject.Inputs[index] = ((IOutputable)tabObject.unit);
        else
            Debug.LogWarning($"{tabObject.unit.Name} is not have output!");
    }

    public override void Subscribe(TabItem item)
    {
        throw new System.Exception("Can not subscribe for inputs group.");
    }

    public abstract void Add();
    public abstract void Show(Unit unit);
    protected abstract void UpdateData(int id);
}
