using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SimulationUpdate();

public class Outflow : EntryUnit
{
    public event SimulationUpdate Step;

    public void Run()
    {
        Queue<Unit> queue = new Queue<Unit>();
        List<Unit> units = new List<Unit>();
        queue.Enqueue(input);
        Unit current;
        while (queue.Count > 0)
        {
            current = queue.Dequeue();
            if (current.AddParentsToEvent(ref queue))
                units.Add(current);
        }
        units.Reverse();
        for (int i = 0; i < units.Count; i++)
            Step += units[i].Tick;
        ControlLaw.dt = Time.fixedDeltaTime;
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
