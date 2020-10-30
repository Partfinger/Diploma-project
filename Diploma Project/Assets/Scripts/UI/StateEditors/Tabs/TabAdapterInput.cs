using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class TabAdapterInput : TabInputEditor
{
    [SerializeField]
    InputField field;

    public void SetCoef(float coeff)
    {
        field.text = coeff.ToString();
    }

    public void SetCoef()
    {
        ((TabAdapterInputsGroup)group).SetCoef(this,float.Parse(Regex.Replace(field.text, "\\.", ",")));
    }
}
