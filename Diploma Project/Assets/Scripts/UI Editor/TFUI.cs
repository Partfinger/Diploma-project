using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TFUI : EditorElement
{
    public DUnit unit;

    public override void ShowProp()
    {

    }

    public override void Init(ref GameObject o)
    {
        unit = o.GetComponent<DUnit>();
    }
}
