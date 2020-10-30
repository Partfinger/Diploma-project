using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabInputEditor : TabItem, IInputEditor
{
    public Text inputText;

    public override void Remove()
    {
        group.Remove(this);
        Destroy(gameObject);
    }

    public void SetInput(string subj)
    {
        inputText.text = subj;
    }

    public void AddInput(TabObject @object)
    {
        ((TabInputsGroup)group).SetInput(this, @object);
        inputText.text = @object.unit.Name;
    }
}
