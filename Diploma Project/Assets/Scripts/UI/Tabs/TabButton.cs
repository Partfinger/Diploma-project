using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public abstract class TabButton : MonoBehaviour, IPointerClickHandler
{
    public TabGroup group;
    public Image background;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        group.OnTabSelected(this);
    }

    public virtual void Exit()
    {
        return;
    }

    public virtual void Select()
    {
        return;
    }

    public abstract void Remove();

    void Start()
    {
        background = GetComponent<Image>();
    }
}
