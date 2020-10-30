using StateEditors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabComparatorInput : TabInputEditor
{
    public Dropdown dropdown;

    public void SetType()
    {
        ((TabComparatorInputsGroup)group).SetInputType(this);
    }

    public void SetType(bool boo)
    {
        dropdown.SetValueWithoutNotify(boo ? 1 : 0);
    }
}
