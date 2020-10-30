using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : Unit, IMultiInput, IMinMax, ITickable, ISimulatable
{
    List<IOutputable> inputs = new List<IOutputable>();
    public List<IOutputable> Inputs { get { return inputs; } set { inputs = value; } }
    public float Min { get { return min; } set { min = value; } }
    public float Max { get { return max; } set { max = value; } }

    public float minShift, min, max;

    public LineDrawer prefabDraver;
    public List<LineDrawer> drawers = new List<LineDrawer>();
    public Transform container, anchor1, anchor2;

    // Настройки драверів
    public int lineCount;
    public float delta;
    public float stepX;//, stepY;
    public float[] points;

    public void AddNew()
    {
        LineDrawer newDrawer = Instantiate(prefabDraver, container);
        newDrawer.color = Color.black;
        newDrawer.display = this;
        drawers.Add(newDrawer);
        inputs.Add(null);
    }

    public void Tick()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            drawers[i].Tick(inputs[i].Output);
        }
    }

    public void StartSimulation()
    {
        GetComponent<Collider>().enabled = false;
        delta = max - min;
        stepX = (anchor2.localPosition.x - anchor1.localPosition.x) / lineCount;
        minShift = Mathf.Abs(min / delta);
        points = new float[lineCount];
        for (int i = 0; i < lineCount; i++)
        {
            points[i] = stepX * i;
        }
        for (int i = 0; i < inputs.Count; i++)
        {
            drawers[i].UpdateDisplaySettings();
        }
    }

    public void StopSimulation()
    {
        GetComponent<Collider>().enabled = true;
    }

    public override void Validate(List<string> logger)
    {
        for (int index = 0; index < inputs.Count; index++)
            if (inputs[index] == null)
                logger.Add($"Не призначений вхід №{index} для {Name}");
    }
}
