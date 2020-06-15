using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransferFunction : MonoBehaviour
{
    public float[] numerator, denumerator;
    protected float[] u, y;

    public float[] Numerator
    {
        get
        {
            return numerator;
        }
        set
        {
            numerator = value;
            Recalculate();
        }
    }

    public float[] Denumerator
    {
        get
        {
            return denumerator;
        }
        set
        {
            denumerator = value;
            Recalculate();
        }
    }

    public TransferFunction()
    {

    }

    public TransferFunction(float[] n, float[] d)
    {
        numerator = n;
        denumerator = d;

        u = new float[n.Length];
        y = new float[d.Length];
    }

    public abstract float FirstTransform(float task);

    public abstract float Transform(float task);

    public abstract void Recalculate();
}
