using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerClickHandler
{
    public TabGroup group;
    public Image background;
    public Text title;
    public SchemeObject schemeObject;
    public static EditorPanelManager panelManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        group.OnTabSelected(this);
    }

    public void Exit()
    {
        schemeObject.propPanel.SetActive(false);
    }

    public void Select()
    {
        schemeObject.propPanel.SetActive(true);
        panelManager.panel = schemeObject.propPanel.GetComponent<EditedPanel>();
    }

    public void Remove()
    {
        schemeObject.Remove();
        group.Remove();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        group.Subscribe(this);
        title.text = name;
    }
}
