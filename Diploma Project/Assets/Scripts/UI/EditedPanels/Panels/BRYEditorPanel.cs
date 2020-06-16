using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public override void Refresh()
    {
        Source s = (Source)parent.boardObject.GetComponent<Unit>();
        InputField[] fields = GetComponentsInChildren<InputField>();
        fields[0].text = s.min.ToString();
        fields[1].text = s.max.ToString();
        fields[2].text = s.start.ToString();
    }
}
