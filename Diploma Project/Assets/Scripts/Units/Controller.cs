using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Unit, IMultiInput, IMultiOutput, ITickable, ISimulatable
{
    List<IOutputable> inputs = new List<IOutputable>(), outputs = new List<IOutputable>();

    public List<IOutputable> Inputs { get { return inputs; } set { inputs = value; } }
    public List<IOutputable> Outputs { get { return outputs; } set { outputs = value; } }

    public List<ControllerChannel> channels = new List<ControllerChannel>();

    public ControllerChannel channelPrefab;

    public void AddNewChannel()
    {
        inputs.Add(null);
        channels.Add(Instantiate(channelPrefab, transform));
    }

    public void Tick()
    {
        for (int i = 0; i < channels.Count; i++)
            channels[i].Tick();
    }

    public void StartSimulation()
    {
        GetComponent<Collider>().enabled = false;
    }

    public void StopSimulation()
    {
        GetComponent<Collider>().enabled = true;
    }
    public override void Validate(List<string> logger)
    {
        for (int index = 0; index < inputs.Count; index++)
        {
            if (inputs[index] == null)
                logger.Add($"Не призначений вхід №{index} для {Name}");
        }
    }
}
