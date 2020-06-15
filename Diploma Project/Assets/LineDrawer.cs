using System;
using UnityEngine;

public class LineDrawer : EntryUnit
{
    // When added to an object, draws colored rays from the
    // transform position.
    public int lineCount = 1000, current;
    public float minY, maxY;
    [SerializeField]
    public float stepX, stepY;
    public float[] points, datas;
    public Color color;
    public Outflow parent;
    float delta;

    static Material lineMaterial;

    public void Start()
    {
        delta = Math.Abs(minY) + Math.Abs(maxY);
        stepX = parent.d.x / lineCount;
        points = new float[lineCount];
        datas = new float[lineCount];
        for (int i =0; i < lineCount; i++)
        {
            points[i] = stepX * i;
        }
    }

    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    public void OnRenderObject()
    {
        CreateLineMaterial();
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);

        GL.Begin(GL.LINE_STRIP);
        for (int i = 0; i < current; i++)
        {
            GL.Vertex3(points[i], datas[i], 0);
            GL.Color(color);
        }
        GL.End();
        GL.PopMatrix();
    }

    public override void Tick()
    {
        datas[current] = input.output / delta;
        if (current < lineCount - 1)
            current++;
        else
        {
            Array.Copy(datas, 1, datas, 0, datas.Length - 1);
        }
    }
}