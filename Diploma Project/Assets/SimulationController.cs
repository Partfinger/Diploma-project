using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationController : MonoBehaviour
{
    public GameObject start, stop;

    public void ClickStart()
    {
        start.SetActive(false);
        stop.SetActive(true);
        DataClass.objectManager.StartSim();
    }

    public void ClickStop()
    {
        stop.SetActive(false);
        start.SetActive(true);
        DataClass.objectManager.StopSim();
    }
}
