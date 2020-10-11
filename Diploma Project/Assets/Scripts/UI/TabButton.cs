using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public abstract class TabButton : TabItem
{
    public Image background;

    public override void OnPointerClick(PointerEventData eventData)
    {
        group.OnTabSelected(this);
    }

    void Start()
    {
        background = GetComponent<Image>();
    }
}
