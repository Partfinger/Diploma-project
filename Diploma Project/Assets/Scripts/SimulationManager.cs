using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class SimulationManager : MonoBehaviour
{
    List<ITickable> tickableUnits;
    List<ISimulatable> movables;
    Unit[] allUnits;
    delegate void GlobalTick();
    event GlobalTick ticker;
    List<string> logger;

    public GameObject start, stop;

    public void ClickStart()
    {
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
        if (Validate())
        {
            FindMovable();
            FindTickable();
            StartCoroutine(GlobalTicker());
            start.SetActive(false);
            stop.SetActive(true);
        }
    }

    private bool Validate()
    {
        logger = new List<string>();
        foreach (Unit unit in allUnits)
        {
            unit.Validate(logger);
        }
        if (logger.Count > 0)
        {
            PrintLog();
            return false;
        }
        return true;
    }

    void PrintLog()
    {
        foreach (string line in logger)
            Debug.Log(line);
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
        foreach (ISimulatable movable in movables)
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
        movables = new List<ISimulatable>();
        for (int i = 0; i < allUnits.Length; i++)
        {
            if (allUnits[i] is ISimulatable)
            {
                (allUnits[i] as ISimulatable).StartSimulation();
                movables.Add(allUnits[i] as ISimulatable);
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
