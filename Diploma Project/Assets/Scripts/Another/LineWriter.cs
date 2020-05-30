using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineWriter : MonoBehaviour
{
    public Unit subject;
    public Material lineMaterial;
    public Color color;
    public Texture2D texture;
    RenderTexture rt;
    public Rect rect;
    [SerializeField]
    int current = 0, max, maxY;
    [SerializeField]
    float stepX, stepY;


    private void Start()
    {
        texture = new Texture2D(1000, 500);
        lineMaterial = new Material(
            Shader.Find("Hidden/Internal-Colored")
        );
        rt = RenderTexture.GetTemporary(texture.width, texture.height);
    }

    public void OnRenderObject()
    {
        //RenderTexture.active = rt;
        GL.Begin(GL.LINES);
        lineMaterial.SetPass(0);
        GL.Color(color);
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(500, subject.output / maxY, 0);
        GL.End();
        /*RenderTexture.active = rt;
        texture.ReadPixels(new Rect(0, 0,
100, 50), 0, 0
);
        texture.Apply(false); // do not apply mipmaps
        texture.Compress(true); // compress with high quality
        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(rt);
        /*GL.PushMatrix();
        // Set black as background color
        GL.Clear(true, false, Color.black);
        lineMaterial.SetPass(0);

        GL.Begin(GL.QUADS);
        GL.Color(Color.red);
        GL.Vertex3(10, 10, 0);
        GL.Vertex3(10, 100, 0);
        GL.Vertex3(100, 100, 0);
        GL.Vertex3(100, 10, 0);

        GL.PopMatrix();
        GL.End();*/
    }

    /*    private void Update()
    {
        line.SetPosition(current, new Vector3(current * stepX,subject.output * stepY, -1));
        current++;
        if (current == max)
        {
            current = 0;
        }
    }*/
}
