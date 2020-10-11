using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorIndicator : MonoBehaviour
{
	[SerializeField]
	ColorPickerEditor editor;
	HSBColor color;
	[SerializeField]
	Material indicatorMaterial;

	void ApplyColor()
	{
		indicatorMaterial.SetColor("_Color", color.ToColor());
		editor.OnColorChange(color);
	}

	public void SetColor(Color c)
    {
		color = new HSBColor(c);
		indicatorMaterial.SetColor("_Color", c);
	}

	public void SetSaturationBrightness(Vector2 sb)
	{
		color.s = sb.x;
		color.b = sb.y;
		ApplyColor();
	}

	public void SetHui(float hui)
    {
		color.h = hui;
		ApplyColor();
	}
}
