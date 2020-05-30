using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EditorPanel : MonoBehaviour
{

    public abstract void SetParent(ref EditorElement element);

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
