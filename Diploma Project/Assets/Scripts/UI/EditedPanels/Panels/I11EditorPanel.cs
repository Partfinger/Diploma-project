using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public override void Refresh()
    {
        Indicator i = (Indicator)parent.boardObject.GetComponent<Unit>();
        InputField[] fields = GetComponentsInChildren<InputField>();
        fields[0].text = i.min.ToString();
        fields[1].text = i.max.ToString();
        /*foreach(InputField field in fields)
        {
            Debug.Log(field.name);
        }*/
    }
}
