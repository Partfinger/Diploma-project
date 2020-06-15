using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SForm : TransferFunction
{
    public static float dt;
    float[] uOld, yOld;
    int n, d;

    public SForm(float[] n, float[] d) : base(n, d)
    {
        uOld = new float[n.Length];
        yOld = new float[d.Length];
    }

    private void Start()
    {
        Recalculate();
    }

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
        yOld[d] = task * numerator[n];
        return 0;
    }

    public override float Transform(float task)
    {
        float yBiggest = 0;
        int index = d - 1;
        int inc = index + 1, num = 1;
        for (; inc > 0; index--, inc--, num++)
        {
            y[index] = yOld[index] + dt * yOld[inc];
            yBiggest -= y[index] * denumerator[num];
        }

        u[0] = task;
        index = 1;
        inc = 0;
        yBiggest += u[0] * numerator[n];
        for (; index <= n; index++, inc++)
        {
            u[index] = (u[inc] - uOld[inc]) / dt;
            yBiggest += u[index] * numerator[index];
        }
        y[y.Length - 1] = yBiggest;
        yOld = y;
        uOld = u;
        return y[0] / denumerator[d];
    }

    /*public override float FirstTransform(float input)
    {
        variables[0] = input;
        variables[nFactor] = input * numerator[nFactor - 1];

        variablesOld = variables;
        variables = new float[dFactor];

        return variablesOld[nFactor];
    }*/

    /*
    public override float Transform(float task)
    {
        float @out = 0;
        int i = 1, k = nFactor - 1, m = 0;

        variables[0] = task;
        @out += task * numerator[k];
        k--;

        for (; i < nFactor; i++, m++, k--)
        {
            variables[i] = (variables[m] - variablesOld[m]) / dt;
            @out += variables[i] * numerator[k];
        }
        k = 0;
        i++;
        m++;
        for (; i < dFactor; i++, m++, k++)
        {
            variables[i] = variablesOld[i] + dt * variablesOld[m];
            @out -= variables[i] * denumerator[k];
        }

        variables[nFactor] = @out / denumerator[nFactor];

        variablesOld = variables;
        variables = new float[dFactor];

        return variablesOld[dFactor - 1];
    }*/
}
