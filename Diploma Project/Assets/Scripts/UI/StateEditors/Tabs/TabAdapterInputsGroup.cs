using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabAdapterInputsGroup : TabInputsGroup
{
    Adapter adapter;

    public override void Show(Unit _adapter)
    {
        subject = _adapter as IMultiInput;
        if (adapter)
        {
            if (adapter != _adapter as Adapter)
            {
                RemoveTabs();
            }
            else
            {
                return;
            }
        }
        adapter = _adapter as Adapter;
        for (int i = 0; i < adapter.Inputs.Count; i++)
        {
            AddPrefab();
            UpdateData(i);
        }
    }

    public override void Add()
    {
        base.AddPrefab();
        adapter.Inputs.Add(null);
        adapter.WeightCoefficient.Add(0);
    }

    public override void Remove(TabItem item)
    {
        int index = tabItems.IndexOf(item);
        adapter.Inputs.RemoveAt(index);
        adapter.WeightCoefficient.RemoveAt(index);
        tabItems.RemoveAt(index);
    }

    protected override void UpdateData(int id)
    {
        TabAdapterInput input = (TabAdapterInput)tabItems[id];
        input.SetCoef(adapter.WeightCoefficient[id]);
        if (adapter.Inputs[id] != null)
            input.SetInput(((Unit)adapter.Inputs[id]).Name);
    }

    public void SetCoef(TabItem item, float newCoef)
    {
        int index = tabItems.IndexOf(item);
        adapter.WeightCoefficient[index] = newCoef;
    }
}
