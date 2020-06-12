using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabComparatorInputsGroup : TabGroup
{
    public Comparator subject;
    List<SchemeObject> objects;
    List<bool> bools;

    private void Start()
    {
        objects = new List<SchemeObject>();
        bools = new List<bool>();
    }

    public override void Subscribe(TabButton button)
    {
        base.Subscribe(button);
        Add();
        button.gameObject.transform.SetAsLastSibling();
    }

    public void Add()
    {
        objects.Add(null);
        bools.Add(false);
    }

    public void Remove(TabButton item)
    {
        int index = tabButtons.IndexOf(item);
        objects.RemoveAt(index);
        bools.RemoveAt(index);
    }

    public override void Remove()
    {
        int index = tabButtons.IndexOf(active);
        objects.RemoveAt(index);
        bools.RemoveAt(index);
        tabButtons.RemoveAt(index);
    }

    public void SetInput(ComparatorInput item, TabSchemeObject schemeObject)
    {
        int index = tabButtons.IndexOf(item);
        item.text.text = schemeObject.name;
        objects[index] = schemeObject.schemeObject;
    }

    public void SetInputType(ComparatorInput item)
    {
        int index = tabButtons.IndexOf(item);
        bools[index] = !bools[index];
    }

    public void SetInputType(ComparatorInput item, bool newType)
    {
        int index = tabButtons.IndexOf(item);
        bools[index] = newType;
    }
}
