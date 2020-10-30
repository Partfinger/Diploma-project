using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Unit, IMultiInput, IMultiOutput, ITickable
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
}
