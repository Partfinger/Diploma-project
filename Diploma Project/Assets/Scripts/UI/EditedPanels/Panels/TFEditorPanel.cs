using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class TFEditorPanel : EditedPanel
{
    public InputField num, denum;
    public GameObject inputDt;
    [SerializeField]
    float[] u, y;
    bool isDiscrete;
    float timeDiscrete = -1;
    DUnit unit;

    private void Start()
    {
        unit = parent.boardObject.GetComponent<DUnit>();
        enabled = false;
    }

    public void SetN()
    {
        string[] strings = num.text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        u = new float[strings.Length];
        for (int i = 0; i < strings.Length; i++)
        {
            u[i] = float.Parse(Regex.Replace(strings[i], "\\.", ","));
        }
        unit.funct.Numerator = u;
    }

    public void SetD()
    {
        string[] strings = denum.text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        y = new float[strings.Length];
        for (int i = 0; i < strings.Length; i++)
        {
            y[i] = float.Parse(Regex.Replace(strings[i], "\\.", ","));
        }
        unit.funct.Denumerator = y;
    }

    public void SetType(bool toggle)
    {
        isDiscrete = toggle;
        TransferFunction tf;
        if (isDiscrete)
        {
            Destroy(unit.funct);
            tf = unit.gameObject.AddComponent<ZForm>();
            tf.numerator = u;
            tf.denumerator = y;
            unit.funct = tf;
            unit.funct.Recalculate();
            inputDt.SetActive(true);
        }
        else
        {
            Destroy(unit.funct);
            tf = unit.gameObject.AddComponent<SForm>();
            tf.numerator = u;
            tf.denumerator = y;
            unit.funct = tf;
            unit.funct.Recalculate();
            inputDt.SetActive(false);
        }
    }

    public void SetTime(string str)
    {
        timeDiscrete = float.Parse(Regex.Replace(str, "\\.", ","));
        ((ZForm)unit.funct).DT = timeDiscrete;
    }
}
