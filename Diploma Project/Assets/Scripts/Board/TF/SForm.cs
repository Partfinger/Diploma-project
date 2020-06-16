using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class SForm : TransferFunction
{
    [SerializeField]
    float[] uOld, yOld;

    public override void Recalculate()
    {
        n = numerator.Length;
        d = denumerator.Length;
        u = new float[n];
        y = new float[d];
        uOld = new float[n];
        yOld = new float[d];
        n--;
        d--;
    }

    public override float FirstTransform(float task)
    {
        uOld[n] = task;
        yOld[0] = task * numerator[n] / denumerator[d];
        return 0;
    }

    //  0    1   2
    //  ud   u
    //  ydd  yd  y
    public override float Transform(float task)
    {
        int current = 1, previous = 0;
        float yBiggest = 0;
        for (; current < d + 1; current++, previous++)
        {
            y[current] = yOld[current] + dt * yOld[previous];
            yBiggest -= y[current] * denumerator[current];
        }

        u[n] = task;
        current = n - 1;
        previous = n;
        yBiggest += task * numerator[n];
        for (; previous > 0; current--, previous--)
        {
            u[current] = (u[previous] - uOld[previous]) / dt;
            yBiggest += u[current] * numerator[current];
        }
        yOld = y;
        yOld[0] = yBiggest / denumerator[0];
        uOld = u;
        y = new float[denumerator.Length];
        u = new float[numerator.Length];
        return yOld[d];
    }
}
