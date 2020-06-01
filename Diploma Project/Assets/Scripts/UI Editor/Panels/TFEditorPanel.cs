using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TFEditorPanel : EditedPanel
{
    public InputField num, denum;
    bool isDiscrete;
    float timeDiscrete;

    public override void Apply()
    {
        TransferFunction tf = parent.boardObject.GetComponent<TransferFunction>();
        string[] strings = num.text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        tf.numerator = new float[strings.Length];
        for (int i = 0; i < strings.Length; i++)
        {
            tf.numerator[i] = float.Parse(strings[i]);
        }

        strings = denum.text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        tf.denumerator = new float[strings.Length];
        for (int i = 0; i < strings.Length; i++)
        {
            tf.denumerator[i] = float.Parse(strings[i]);
        }
        tf.ResetTF();
        //parent.unit.input
    }

    public override void Show()
    {
        TransferFunction tf = parent.boardObject.GetComponent<TransferFunction>();
        base.Show();
        num.text = string.Join(" ", tf.numerator);
        denum.text = string.Join(" ", tf.denumerator);
    }

}
