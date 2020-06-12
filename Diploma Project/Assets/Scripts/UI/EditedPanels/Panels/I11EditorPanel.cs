using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I11EditorPanel : EditedPanel
{
    public void EditMin(string value)
    {
        if (value.Length > 0)
            ((Indicator)parent.boardObject.GetComponent<Unit>()).min = float.Parse(value);
    }

    public void EditMax(string value)
    {
        if (value.Length > 0)
            ((Indicator)parent.boardObject.GetComponent<Unit>()).max = float.Parse(value);
    }
}
