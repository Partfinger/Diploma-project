using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class TabSchemeObject : TabButton, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Text title;
    public SchemeObject schemeObject;
    public int EditorObjectID;
    public static int ID = 0;
    public string Name;

    void Start()
    {
        GetName();
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
        DataClass.panelManager.panel = schemeObject.propPanel.GetComponent<EditedPanel>();
    }

    public void ShowOptions()
    {
        schemeObject.propPanel.SetActive(true);
        if (schemeObject.haveInput)
        {
            DataClass.panelManager.inputPanel.SetActive(true);
            DataClass.panelManager.inputPanel.transform.GetChild(1).GetComponentInChildren<Text>().text = schemeObject.Input ? schemeObject.Input.name : "Вибрати";
        }
    }

    public void HideOptions()
    {
        schemeObject.propPanel.SetActive(false);
        DataClass.panelManager.inputPanel.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        foreach (GameObject @object in eventData.hovered)
        {
            if (@object.tag == "SchemeObject")
            {
                DataClass.panelManager.captured = @object.GetComponent<TabSchemeObject>();
                if (DataClass.panelManager.captured is TabSchemeMIK)
                {
                    DataClass.panelManager.itIsController = true;
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
                DataClass.panelManager.AddInput(@object);
                break;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        return;
    }

    public virtual bool HasInputs()
    {
        return schemeObject.Input;
    }

    public int GetIDInput()
    {
        return group.tabButtons.IndexOf(schemeObject.Input.gameObject.GetComponent<TabSchemeObject>());
    }

    public abstract void GetName();

    public abstract void Save(BinaryWriter writer);

    public abstract void Load(BinaryReader reader);

    public abstract void LoadInputs(BinaryReader reader);
}
