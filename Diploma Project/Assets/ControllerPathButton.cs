using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPathButton : TabItem
{
    public override void Remove()
    {
        Destroy(gameObject);
    }

    public void Click()
    {
        group.OnTabSelected(this);
    }
}
