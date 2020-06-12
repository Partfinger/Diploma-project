using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class TabButton : MonoBehaviour, IPointerClickHandler
{
    public TabGroup group;
    public Image background;

    public void OnPointerClick(PointerEventData eventData)
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

    public void Save()
    {

    }

    public void Load()
    {
        
    }
}
