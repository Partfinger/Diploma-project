using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comparator : Unit
{
    public Unit another;

    public override void Tick()
    {
        output = input.output - another.output;
    }

    private void Start()
    {
        output = input.output - another.output;
        Debug.Log("1as");
    }

}
