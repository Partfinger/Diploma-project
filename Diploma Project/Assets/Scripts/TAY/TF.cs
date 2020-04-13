﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TF
{
    public float[] numerator, denumerator, variables, variablesOld;
    [SerializeField]
    int dFactor, nFactor;
    float dt;

    public void Awake()
    {
        nFactor = numerator.Length;
        dFactor = denumerator.Length + nFactor;
        variables = new float[dFactor];
        dt = Time.fixedDeltaTime;
    }

    /*
    public TF(float[] n, float[] d)
    {
        nominator = n;
        denominator = d;
        dFactor = denominator.Length;
        nFactor = nominator.Length + dFactor;
        variables = new float[nFactor];
    }*/

    public float FirstTransform(float input)
    {
        variables[0] = input;
        variables[nFactor] = input * numerator[nFactor - 1];

        variablesOld = variables;
        variables = new float[dFactor];

        return variablesOld[nFactor];
    }



    public float Transform(float task)
    {
        float newFirst = 0;
        int i = 1, k = nFactor - 1, m = 0;

        variables[0] = task;
        newFirst += task * numerator[k];
        k--;

        for (; i < nFactor; i++, m++, k--)
        {
            variables[i] = (variables[m] - variablesOld[m]) / dt;
            newFirst += variables[i] * numerator[k];
        }
        k = 0;
        i++;
        m++;
        for (; i < dFactor; i++, m++, k++)
        {
            variables[i] = variablesOld[i] + dt * variablesOld[m];
            newFirst -= variables[i] * denumerator[k];
        }

        variables[nFactor] = newFirst / denumerator[nFactor];

        variablesOld = variables;
        variables = new float[dFactor];

        return variablesOld[dFactor - 1];
    }
}
