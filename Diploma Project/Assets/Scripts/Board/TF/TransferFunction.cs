using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Передатня функція
/// </summary>
public abstract class TransferFunction : MonoBehaviour
{
    public float[] numerator, denumerator;
    [SerializeField]
    protected float[] u, y;
    protected int n, d;
    public static float dt;

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

    public abstract float FirstTransform(float task);

    public abstract float Transform(float task);

    public abstract void Recalculate();

    public virtual void Save(BinaryWriter writer)
    {
        writer.Write(numerator.Length);
        for (int i = 0; i < numerator.Length; i++)
        {
            writer.Write(numerator[i]);
        }
        writer.Write(denumerator.Length);
        for (int i = 0; i < denumerator.Length; i++)
        {
            writer.Write(denumerator[i]);
        }
    }

    public virtual void Load(BinaryReader reader)
    {
        int num = reader.ReadInt32();
        numerator = new float[num];
        for (int i = 0; i < num; i++)
        {
            numerator[i] = reader.ReadSingle();
        }
        num = reader.ReadInt32();
        denumerator = new float[num];
        for (int i = 0; i < num; i++)
        {
            denumerator[i] = reader.ReadSingle();
        }
        Recalculate();
    }
}
