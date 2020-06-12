using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class TabSchemeObject : TabButton, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Text title;
    public static EditorPanelManager panelManager;
    public SchemeObject schemeObject;

    void Start()
    {
        title.text = name;
    }

    public override void Exit()
    {
        HideOptions();
    }

    public override void Remove()
    {
        HideOptions();
        schemeObject.Remove();
        group.Unsubscribe();
        Destroy(gameObject);
    }

    public override void Select()
    {
        ShowOptions();
        panelManager.panel = schemeObject.propPanel.GetComponent<EditedPanel>();
    }

    public void ShowOptions()
    {
        schemeObject.propPanel.SetActive(true);
        if (schemeObject.haveInput)
        {
            panelManager.inputPanel.SetActive(true);
            panelManager.inputPanel.transform.GetChild(1).GetComponentInChildren<Text>().text = schemeObject.Input ? schemeObject.Input.name : "Вибрати";
        }
    }

    public void HideOptions()
    {
        schemeObject.propPanel.SetActive(false);
        panelManager.inputPanel.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        foreach (GameObject @object in eventData.hovered)
        {
            if (@object.tag == "SchemeObject")
            {
                panelManager.captured = @object.GetComponent<TabSchemeObject>();
                if (panelManager.captured is TabSchemeMIK)
                {
                    panelManager.itIsController = true;
                }
                break;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        foreach (GameObject @object in eventData.hovered)
        {
            if (@object.tag == "DragDropZone")
            {
                panelManager.AddInput(@object);
                break;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        return;
    }
}
