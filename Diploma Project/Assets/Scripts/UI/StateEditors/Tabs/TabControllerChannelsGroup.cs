using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabControllerChannelsGroup : TabInputsGroup
{
    Controller controller;
    public override void Add()
    {
        base.AddPrefab();
        controller.AddNewChannel();
        /*TabControllerChannel channel = Instantiate(inputPrefab, rect) as TabControllerChannel;
        channel.group = this;
        tabItems.Add(channel);*/
    }

    public override void Remove(TabItem item)
    {
        int index = tabItems.IndexOf(item);
        tabItems.RemoveAt(index);
        Destroy(controller.channels[index].gameObject);
        controller.channels.RemoveAt(index);
    }

    public override void Show(Unit unit)
    {
        subject = unit as IMultiInput;
        if (controller)
        {
            if (controller != unit as Controller)
            {
                RemoveTabs();
            }
            else
            {
                return;
            }
        }
        controller = unit as Controller;
        for (int i = 0; i < controller.Inputs.Count; i++)
        {
            AddPrefab();
            UpdateData(i);
        }
    }

    protected override void UpdateData(int id)
    {
        ((TabControllerChannel)tabItems[id]).channel = controller.channels[id];
    }
}
