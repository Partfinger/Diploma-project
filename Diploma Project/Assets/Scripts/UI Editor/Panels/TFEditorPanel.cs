using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TFEditorPanel : EditorPanel
{
    public TFUI parent;
    public InputField num, denum;
    bool isDiscrete;
    float timeDiscrete;

    public override void SetParent(ref EditorElement element)
    {
        parent = (TFUI)element;
    }

    public override void Apply()
    {
        string[] strings = num.text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        parent.unit.funct.numerator = new float[strings.Length];
        for (int i = 0; i < strings.Length; i++)
        {
            parent.unit.funct.numerator[i] = float.Parse(strings[i]);
        }

        strings = denum.text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        parent.unit.funct.denumerator = new float[strings.Length];
        for (int i = 0; i < strings.Length; i++)
        {
            parent.unit.funct.denumerator[i] = float.Parse(strings[i]);
        }
        parent.unit.funct.ResetTF();
        //parent.unit.input
    }

    public override void Show()
    {
        base.Show();
        num.text = string.Join(" ", parent.unit.funct.numerator);
        denum.text = string.Join(" ", parent.unit.funct.denumerator);
    }

}
