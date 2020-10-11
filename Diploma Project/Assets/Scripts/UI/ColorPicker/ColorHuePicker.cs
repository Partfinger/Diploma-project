using UnityEngine;
using UnityEngine.EventSystems;

public class ColorHuePicker : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    RectTransform rect;
    [SerializeField]
    ColorPanelPicker colorPanel;
    [SerializeField]
    ColorIndicator indicator;

    void SetColor(HSBColor color)
	{
		SendMessage("SetDragPoint", new Vector3(color.h, 0, 0));
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 localCursor, normalized;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localCursor))
            return;
        normalized = localCursor / rect.sizeDelta + Vector2.up;
        colorPanel.SetHue(normalized.x);
        indicator.SetHui(normalized.x);
    }
}
