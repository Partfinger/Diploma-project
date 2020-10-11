using StateEditors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabComparatorInput : TabItem, IInputEditor
{
    public Text text;
    public Dropdown dropdown;

    public void SetType()
    {
        ((TabComparatorInputsGroup)group).SetInputType(this);
    }

    public void SetType(bool boo)
    {
        dropdown.SetValueWithoutNotify(boo ? 1 : 0);
    }

    public override void Remove()
    {
        ((TabComparatorInputsGroup)group).Remove(this);
        Destroy(gameObject);
    }

    public void AddInput(TabObject @object)
    {
        ((TabComparatorInputsGroup)group).SetInput(this, @object);
        text.text = @object.unit.Name;
    }

    public void SetInput(string subj)
    {
        text.text = subj;
    }
}
