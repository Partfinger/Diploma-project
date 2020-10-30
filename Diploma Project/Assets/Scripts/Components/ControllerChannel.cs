using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerChannel : MonoBehaviour
{
    public int ID;
    public List<ControllerLaw> laws;
    public Controller controller;

    public void Tick()
    {
        float control = 0, input = controller.Inputs[ID].Output;
        for (int i = 0; i < laws.Count; i++)
        {
            control += laws[i].SetTask(input);
        }
        controller.Outputs[ID].Output = control;
    }
}
