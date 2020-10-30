using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabControllerChannel : TabInputEditor
{
    public ControllerChannel channel;

    public override void Remove()
    {
        group.Remove(this);
        Destroy(gameObject);
    }
}
