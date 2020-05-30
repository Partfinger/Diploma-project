using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TFUI : EditorElement
{
    public DUnit unit;

    public override void ShowProp()
    {
        if (manager.current != this)
        {
            if(manager.current)
            {
                manager.Hide();
            }
            manager.current = this;
            panel.Show();
        }
    }

    public override void Init(ref GameObject o)
    {
        unit = o.GetComponent<DUnit>();
    }
}
