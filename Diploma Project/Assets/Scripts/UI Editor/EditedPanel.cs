using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EditedPanel : MonoBehaviour
{
    public bool haveInput;

    public SchemeObject parent;

    public abstract void Apply();

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
