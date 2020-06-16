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
    public Toggle check;
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
        u = Handle(num.text);
        unit.funct.Numerator = u;
    }

    public void SetD()
    {
        y = Handle(denum.text);
        unit.funct.Denumerator = y;
    }

    float[] Handle(string s)
    {
        string[] strings = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        float[] array = new float[strings.Length];
        for (int i = 0; i < strings.Length; i++)
        {
            array[i] = float.Parse(Regex.Replace(strings[i], "\\.", ","));
        }
        return array;
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
            //inputDt.SetActive(true);
        }
        else
        {
            Destroy(unit.funct);
            tf = unit.gameObject.AddComponent<SForm>();
            tf.numerator = u;
            tf.denumerator = y;
            unit.funct = tf;
            unit.funct.Recalculate();
            //inputDt.SetActive(false);
        }
    }

    public void SetTime(string str)
    {

    }

    public override void Refresh()
    {
        unit = parent.boardObject.GetComponent<DUnit>();
        for (int i = 0; i < unit.funct.numerator.Length; i++)
        {
            num.text += unit.funct.numerator[i] + " ";
        }
        for (int i = 0; i < unit.funct.denumerator.Length; i++)
        {
            denum.text += unit.funct.denumerator[i] + " ";
        }

        if (unit.funct is ZForm)
        {
            check.isOn = true;
            //inputDt.GetComponent<InputField>().text = ((ZForm)unit.funct).DT.ToString();
        }
    }
}
