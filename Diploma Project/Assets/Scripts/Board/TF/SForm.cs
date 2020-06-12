using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SForm : TransferFunction
{
    public static float dt;
    float[] variables, variablesOld;
    int dFactor, nFactor;

    public SForm(float[] n, float[] d) : base(n, d)
    {
        dFactor = denumerator.Length;
        nFactor = numerator.Length + dFactor;
        variables = new float[nFactor];
    }

    public override float FirstTransform(float input)
    {
        variables[0] = input;
        variables[nFactor] = input * numerator[nFactor - 1];

        variablesOld = variables;
        variables = new float[dFactor];

        return variablesOld[nFactor];
    }

    public override void Recalculate()
    {
        dFactor = denumerator.Length;
        nFactor = numerator.Length + dFactor;
        variables = new float[nFactor];
    }

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
    }
}
