using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MonitorInput : TabButton
{
    public MonitorEditorPanel panel;

    SchemeObject input;
    public Image image;
    public Text text;

    public SchemeObject Input
    {
        get
        {
            return input;
        }
        set
        {
            input = value;
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        return;
    }

    public override void Remove()
    {
        panel.Remove(this);
        Destroy(gameObject);
    }
}
