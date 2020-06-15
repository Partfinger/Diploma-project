using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public TabButton active;
    public Color tabIdle, tabActive;

    public virtual void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void Unsubscribe()
    {
        tabButtons.Remove(active);
    }

    public void Unsubscribe(TabButton button)
    {
        tabButtons.Remove(button);
    }

    public virtual void OnTabSelected(TabButton button)
    {
        if (active == button)
        {
            return;
        }
        else if (active)
        {
            active.Exit();
            active.background.color = tabIdle;
        }
        active = button;
        active.background.color = tabActive;
        active.Select();
    }

    public virtual void Remove()
    {
        return;
    }

    public void ResetTabs()
    {
        foreach(TabButton tab in tabButtons)
        {
            tab.background.color = tabIdle;
        }
    }
}
