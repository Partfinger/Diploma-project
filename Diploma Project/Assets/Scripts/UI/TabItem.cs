using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class TabItem : MonoBehaviour, IPointerClickHandler
{
    public TabGroup group;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        return;
    }

    public abstract void Remove();

    public virtual void Select()
    {
        return;
    }

    public virtual void Exit()
    {
        return;
    }
}
