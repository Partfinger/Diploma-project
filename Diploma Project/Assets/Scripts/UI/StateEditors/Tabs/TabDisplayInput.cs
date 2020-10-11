using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabDisplayInput : TabItem, IInputEditor
{
    public Color color;
    public Text text;
    public Image image;

    public void AddInput(TabObject @object)
    {
        ((TabDisplayInputsGroup)group).SetInput(this, @object);
        text.text = @object.unit.Name;
    }

    public void SetInput(string subj)
    {
        text.text = subj;
    }

    public override void Remove()
    {
        group.Remove(this);
    }

    public void SetColor(Color _color)
    {
        color = _color;
        image.color = color;
    }

    public void ClickColorPanel()
    {
        ((TabDisplayInputsGroup)group).CallColorPicker(this);
    }
}
