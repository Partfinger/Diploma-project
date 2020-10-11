using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TabGroup : MonoBehaviour
{
    public List<TabItem> tabItems;
    public TabItem active;

    public virtual void Subscribe(TabItem item)
    {
        if (tabItems == null)
        {
            tabItems = new List<TabItem>();
        }
        tabItems.Add(item);
    }

    public void Unsubscribe()
    {
        tabItems.Remove(active);
    }

    public void Unsubscribe(TabButton button)
    {
        tabItems.Remove(button);
    }

    public virtual void OnTabSelected(TabItem item)
    {
        if (active == item)
        {
            return;
        }
        else if (active)
        {
            active.Exit();
            //active.background.color = tabIdle;
        }
        //active = button;
        //active.background.color = tabActive;
        active.Select();
    }

    public virtual void Remove()
    {
        return;
    }

    public abstract void Remove(TabItem item);

    public virtual void RemoveTabs()
    {
        for (int i = 0; i < tabItems.Count; i++)
        {
            Destroy(tabItems[i].gameObject);
        }
        tabItems.Clear();
    }
}
