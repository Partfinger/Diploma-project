using System;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    // When added to an object, draws colored rays from the
    // transform position.
    public int current;
    public float[] datas;
    public Color color;
    public Display display;

    static Material lineMaterial;

    public void UpdateDisplaySettings()
    {
        datas = new float[display.lineCount];
        current = 0;
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
            GL.Vertex3(display.points[i], datas[i], 0);
            GL.Color(color);
        }
        GL.End();
        GL.PopMatrix();
    }

    public void Tick(float input)
    {
        datas[current] = input / display.delta;
        if (current < display.lineCount - 1)
            current++;
        else
        {
            Array.Copy(datas, 1, datas, 0, datas.Length - 1);
        }
    }
}