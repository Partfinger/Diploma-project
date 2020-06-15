using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SimulationUpdate();

public class Outflow : Unit
{
    public event SimulationUpdate Step;

    public List<Unit> inputs;
    public List<Color> colors;
    public LineDrawer prefabDraver;
    public List<LineDrawer> drawers;
    public Transform container, anchor1, anchor2;
    public Vector3 d;
    public float max, min;

    public void Start()
    {
        d = anchor2.localPosition - anchor1.localPosition;
        SForm.dt = Time.fixedDeltaTime;
        Queue<Unit> queue = new Queue<Unit>();
        List<Unit> unitsForUpdate = new List<Unit>();
        for (int i = 0; i < inputs.Count; i++)
            queue.Enqueue(inputs[i]);
        Unit current;
        while (queue.Count > 0)
        {
            current = queue.Dequeue();
            if (current.AddParentsToEvent(ref queue))
                unitsForUpdate.Add(current);
        }
        unitsForUpdate.Reverse();
        for (int i = 0; i < unitsForUpdate.Count; i++)
            Step += unitsForUpdate[i].Tick;
        ControlLaw.dt = Time.fixedDeltaTime;
        for (int i = 0; i < inputs.Count; i++)
        {
            LineDrawer drawer = Instantiate(prefabDraver, container);
            drawer.input = inputs[i];
            drawer.color = colors[i];
            drawer.parent = this;
            drawer.maxY = max;
            drawer.minY = min;
            drawers.Add(drawer);
            Step += drawer.Tick;
        }
        StartCoroutine(Cycle());
    }

    public override void Tick()
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator Cycle()
    {
        while(true)
        {
            yield return new WaitForFixedUpdate();
            Step();
        }
    }
}
