using System;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    // When added to an object, draws colored rays from the
    // transform position.
    public int lineCount = 1000, current;
    public Transform anchor1, anchor2;
    public float maxX, maxY;
    [SerializeField]
    float stepX, stepY;
    public float[] points, datas;
    public Unit input;
    public Color color;

    static Material lineMaterial;



    public void Start()
    {
        Vector3 d = anchor2.localPosition - anchor1.localPosition;
        maxX = d.x;
        maxY = d.z;
        stepX = maxX / lineCount;
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
        // Apply the line material
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        // Set transformation matrix for drawing to
        // match our transform
        GL.MultMatrix(transform.localToWorldMatrix);

        // Draw lines
        GL.Begin(GL.LINE_STRIP);
        for (int i = 0; i < current; i++)
        {
            GL.Vertex3(points[i], datas[i], 0);
            GL.Color(color);
            /*
            float a = i / (float)lineCount;
            float angle = a * Mathf.PI * 2;
            // Vertex colors change from red to green
            GL.Color(new Color(a, 1 - a, 0, 0.8F));
            // One vertex at transform position
            GL.Vertex3(0, 0, 0);
            // Another vertex at edge of circle
            GL.Vertex3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            */
        }
        GL.End();
        GL.PopMatrix();
    }

    private void FixedUpdate()
    {
        datas[current] = input.output;
        if (current < lineCount - 1)
            current++;
        else
        {
            Array.Copy(datas, 1, datas, 0, datas.Length - 1);
        }
    }
}