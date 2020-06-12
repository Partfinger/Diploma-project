using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstantEditorPanel : EditedPanel
{
    public void ChangeValue(string value)
    {
        if (value.Length > 0)
            ((Constant)parent.boardObject.GetComponent<Unit>())._const = float.Parse(value);
    }
}
