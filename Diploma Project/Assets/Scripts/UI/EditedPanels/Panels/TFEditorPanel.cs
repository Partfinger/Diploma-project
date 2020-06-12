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
        string[] strings = num.text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
        if (isDiscrete)
        {
            unit.funct = new ZForm(u, y);
            inputDt.SetActive(true);
        }
        else
        {
            unit.funct = new SForm(u, y);
            inputDt.SetActive(false);
        }
    }

    public void SetTime(string str)
    {
        timeDiscrete = float.Parse(Regex.Replace(str, "\\.", ","));
        ((ZForm)unit.funct).DT = timeDiscrete;
    }

    /*
    public override void Apply()
    {
        TransferFunction tf = parent.boardObject.GetComponent<TransferFunction>();
        string[] strings = num.text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        tf.numerator = new float[strings.Length];
        try
        {
            for (int i = 0; i < strings.Length; i++)
            {
                tf.numerator[i] = float.Parse(strings[i]);
            }
        }
        catch (FormatException e)
        {

        }

        strings = denum.text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        tf.denumerator = new float[strings.Length];
        try
        {
            for (int i = 0; i < strings.Length; i++)
            {
                tf.denumerator[i] = float.Parse(strings[i]);
            }
            tf.ResetTF();
        }
        catch (FormatException e)
        {

        }
        //parent.unit.input
    }

    /*public override void Show()
    {
        TransferFunction tf = parent.boardObject.GetComponent<TransferFunction>();
        base.Show();
        num.text = string.Join(" ", tf.numerator);
        denum.text = string.Join(" ", tf.denumerator);
    }*/

}
