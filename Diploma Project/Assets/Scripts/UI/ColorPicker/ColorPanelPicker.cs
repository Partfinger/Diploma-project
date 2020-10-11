using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorPanelPicker : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    ColorIndicator indicator;
    [SerializeField]
    RectTransform rect;
    [SerializeField]
    Material background;

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 localCursor, normalized;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localCursor))
            return;
        normalized = localCursor / rect.sizeDelta + Vector2.up;
        indicator.SetSaturationBrightness(normalized);
    }

    public void SetHue(float hue)
    {
        background.SetColor("_Color", new HSBColor(hue, 1, 1).ToColor());
    }

    public void SetHue(Color color)
    {
        background.SetColor("_Color", color);
    }

}
