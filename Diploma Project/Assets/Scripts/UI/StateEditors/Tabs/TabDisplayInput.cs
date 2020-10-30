using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabDisplayInput : TabInputEditor
{
    public Color color;
    public Image image;

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
