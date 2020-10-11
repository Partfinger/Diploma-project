using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineWriter : MonoBehaviour
{
    public LineRenderer line;
    public Transform anchor1, anchor2;
    public UnitOld subject;
    [SerializeField]
    int current = 0, max, maxY;
    [SerializeField]
    float stepX, stepY;

    private void Start()
    {
        Vector3 delta = anchor2.localPosition - anchor1.localPosition;
        stepX = delta.x / max;
        stepY = delta.y / maxY;
        line.positionCount = max;
    }

    private void Update()
    {
        line.SetPosition(current, new Vector3(current * stepX, subject.output * stepY, -1));
        current++;
        if (current == max)
        {
            current = 0;
        }
    }
}
