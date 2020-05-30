using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EditorElement : MonoBehaviour
{
    public Text text;
    public GameObject subject;
    public EditorPanel panel;
    public static EditorObjectManager manager;
    public static Transform panelUI, container;

    void Start()
    {
        text.text = subject.name;
        //Form();
    }

    public abstract void ShowProp();

    public abstract void Init(ref GameObject t);
}
