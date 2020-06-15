using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ComparatorInput : TabButton
{
    public Text text;
    public ComparatorEditorPanel panel;

    public void SetType(int i)
    {
        panel.SetType(group.tabButtons.IndexOf(this), i == 1);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        return;
    }

    public override void Remove()
    {
        panel.Remove(transform.GetSiblingIndex() - 2);
        ((TabComparatorInputsGroup)group).Remove(this);
        group.Unsubscribe(this);
        Destroy(gameObject);
    }
}
