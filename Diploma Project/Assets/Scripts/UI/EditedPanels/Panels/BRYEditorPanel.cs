using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BRYEditorPanel : EditedPanel
{
    public void EditMin(string value)
    {
        if (value.Length > 0)
            ((Source)parent.boardObject.GetComponent<Unit>()).min = float.Parse(value);
    }

    public void EditMax(string value)
    {
        if (value.Length > 0)
            ((Source)parent.boardObject.GetComponent<Unit>()).max = float.Parse(value);
    }

    public void EditStart(string value)
    {
        if (value.Length > 0)
        {
            Source source = (Source)parent.boardObject.GetComponent<Unit>();
            source.start = float.Parse(value);
            source.UpdatePanel();
        }
    }
}
