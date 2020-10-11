using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimulationManager : MonoBehaviour
{
    List<ITickable> tickableUnits;
    List<IMovable> movables;
    Unit[] allUnits;
    delegate void GlobalTick();
    event GlobalTick ticker;

    public GameObject start, stop;

    public void ClickStart()
    {
        start.SetActive(false);
        stop.SetActive(true);
        StartSimulation();
    }

    public void ClickStop()
    {
        stop.SetActive(false);
        start.SetActive(true);
        StopSimulation();
    }

    public void StartSimulation()
    {
        allUnits = FindObjectsOfType<Unit>();
        FindMovable();
        FindTickable();
        StartCoroutine(GlobalTicker());
    }

    private IEnumerator GlobalTicker()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            ticker();
        }
    }

    public void StopSimulation()
    {
        StopAllCoroutines();
        foreach (ITickable subject in tickableUnits)
        {
            ticker -= subject.Tick;
        }
        foreach (IMovable movable in movables)
        {
            movable.StopSimulation();
        }
    }

    void FindTickable()
    {
        tickableUnits = new List<ITickable>();
        for (int i = 0; i < allUnits.Length; i++)
        {
            if (allUnits[i] is ITickable)
            {
                tickableUnits.Add(allUnits[i] as ITickable);
                ticker += (allUnits[i] as ITickable).Tick;
            }
        }
    }

    void FindMovable()
    {
        movables = new List<IMovable>();
        for (int i = 0; i < allUnits.Length; i++)
        {
            if (allUnits[i] is IMovable)
            {
                (allUnits[i] as IMovable).StartSimulation();
                movables.Add(allUnits[i] as IMovable);
            }
        }
        Tuner[] tuners = FindObjectsOfType<Tuner>();
        for (int i = 0; i < tuners.Length; i++)
        {
            tuners[i].StartSimulation();
            movables.Add(tuners[i]);
        }
    }
}
