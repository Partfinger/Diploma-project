using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public delegate void SimulationUpdate();

public class Outflow : UnitOld
{
    public event SimulationUpdate Step;

    public List<UnitOld> inputs;
    public List<Color> colors;
    public LineDrawer prefabDraver;
    public List<LineDrawer> drawers;
    public Transform container, anchor1, anchor2;
    public float max, min;

    public void Start()
    {
        /*
        d = anchor2.localPosition - anchor1.localPosition;
        TransferFunction.dt = Time.fixedDeltaTime;
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
        Indicator[] uns = FindObjectsOfType<Indicator>();
        for (int i = 0; i < uns.Length; i++)
            Step += uns[i].Tick;
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
        */
    }

    internal void StopSim()
    {
        foreach(Delegate d in Step.GetInvocationList())
        {
            Step -= (SimulationUpdate)d;
        }
        StopAllCoroutines();
    }

    public override void Tick()
    {
    }

    public void StartCoroutineStep()
    {
        //StartCoroutine(Cycle());
    }

}
