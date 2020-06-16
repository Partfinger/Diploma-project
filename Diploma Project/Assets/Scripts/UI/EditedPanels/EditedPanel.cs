using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EditedPanel : MonoBehaviour
{
    public bool haveInput;
    public bool haveSeveralInputs;

    public SchemeObject parent;
    public static ContentSizeFitter fitter;
    public static LayoutGroup layoutGroup;

    public virtual void AddInput(GameObject dropZone)
    {
        return;
    }

    public abstract void Refresh();
}
