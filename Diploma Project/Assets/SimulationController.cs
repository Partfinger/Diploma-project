using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationController : MonoBehaviour
{
    public GameObject start, pause, stop, resume;

    public void ClickStart()
    {
        start.SetActive(false);
        stop.SetActive(true);
        pause.SetActive(true);
    }

    public void ClickStop()
    {
        stop.SetActive(false);
        pause.SetActive(false);
        resume.SetActive(false);
        start.SetActive(true);
    }

    public void ClickPause()
    {
        pause.SetActive(false);
        resume.SetActive(true);
    }

    public void ClickResume()
    {
        resume.SetActive(false);
        pause.SetActive(true);
    }
}
