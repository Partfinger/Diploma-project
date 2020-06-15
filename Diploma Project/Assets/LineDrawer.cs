using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public List<Unit> inputs;
    public List<Color> colors;
    public float secs;
    int lenght, current;

    private void Start()
    {
        lenght = (int)(secs / Time.fixedDeltaTime);
        current = lenght - 1;
    }
}
