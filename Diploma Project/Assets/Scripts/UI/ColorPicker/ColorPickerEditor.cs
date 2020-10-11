using StateEditors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickerEditor : MonoBehaviour
{
	[SerializeField]
    Color color;
	[SerializeField]
	ColorIndicator indicator;
	[SerializeField]
	ColorPanelPicker colorPanelPicker;
	[SerializeField]
	public EditorProvider provider;

	public void OnColorChange(HSBColor color)
	{
		this.color = color.ToColor();
	}

    public void Show(Color color)
    {
		gameObject.SetActive(true);
		indicator.SetColor(color);
		colorPanelPicker.SetHue(color);
	}

	public void Close()
	{
		gameObject.SetActive(false);
	}

	public void Apply()
    {
		color.a = 1;
		provider.colorSetable.SetColor(color);
		gameObject.SetActive(false);
	}
}
