using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ZForm : TransferFunction
{
    public override float FirstTransform(float task)
    {
        u[1] = task;
        y[1] = u[1] * numerator[0];
        return y[1];
    }

    //  0    1       2
    //  u    u-1     u-2
    //  y    y-1     y-2

    public override float Transform(float task)
    {
        float @out = 0;
        u[0] = task;
        int iterator = 0;
        for (; iterator < n; iterator++)
        {
            @out += u[iterator] * numerator[iterator];
        }

        iterator = d - 1;
        for (; iterator > 0; iterator--)
        {
            @out -= y[iterator] * denumerator[iterator];
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
        n = numerator.Length;
        d = denumerator.Length;
        u = new float[n];
        y = new float[d];
    }

    public override void Save(BinaryWriter writer)
    {
        base.Save(writer);
        writer.Write(dt);
    }

    public override void Load(BinaryReader reader)
    {
        base.Load(reader);
        dt = reader.ReadSingle();
    }
}
