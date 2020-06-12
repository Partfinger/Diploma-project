using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComparatorInput : TabButton
{
    public Text text;
    public static ComparatorEditorPanel panel;

    public override void Remove()
    {
        panel.Remove(transform.GetSiblingIndex() - 2);
        ((TabComparatorInputsGroup)group).Remove(this);
        group.Unsubscribe(this);
        Destroy(gameObject);
    }
}
