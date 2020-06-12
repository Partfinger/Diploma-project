using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZForm : TransferFunction
{
    public float DT { get; set; }
    float[] u, y;

    public ZForm(float[] n, float[] d) : base(n, d)
    {
        u = new float[n.Length];
        y = new float[d.Length];
    }

    public override float FirstTransform(float task)
    {
        u[1] = task * numerator[0];
        y[1] = u[1];
        return y[1];
    }

    public override float Transform(float task)
    {
        float @out = 0;
        u[0] = task;
        for (int i = 0; i < u.Length; i++)
        {
            @out += u[i] * numerator[i];
        }

        for (int i = y.Length; i > 0; --i)
        {
            @out -= y[i] * denumerator[i];
        }
        y[0] = @out;
        Shift();
        return y[0];
    }

    void Shift()
    {
        Array.Copy(u, 0, u, 1, u.Length - 1);
        Array.Copy(y, 0, y, 1, y.Length - 1);
    }

    public override void Recalculate()
    {
        u = new float[numerator.Length];
        y = new float[denumerator.Length];
    }
}
