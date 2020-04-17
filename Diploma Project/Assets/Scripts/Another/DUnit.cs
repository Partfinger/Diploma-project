using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DUnit : Unit
{
    [SerializeField]
    public TF funct;

    private void Awake()
    {
        funct.Awake();
    }

    private void Start()
    {
        output = funct.FirstTransform(input.output);
    }

    public override void Tick()
    {
        output = funct.Transform(input.output);
    }
}
