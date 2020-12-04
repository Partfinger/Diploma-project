using StateEditors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabObject : TabButton, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Unit unit;
    public Text text;
    public static EditorProvider provider;

    public override void Remove()
    {
        Exit();
        Destroy(unit.gameObject);
        Destroy(gameObject);
    }

    public int GetID()
    {
        return group.tabItems.IndexOf(this);
    }

    public override void Select()
    {
        for (int i = 0; i < unit.editors.Length; i++)
        {
            StateEditor editor = provider.Get(unit.editors[i]);
            editor.Show(unit);
        }
        Debug.Log(GetID());
    }

    public override void Exit()
    {
        provider.HideEditors();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ((TabObjectManager)group).captured = this;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        foreach (GameObject @object in eventData.hovered)
        {
            if (@object.tag == "DragDropZone")
            {
                ((TabObjectManager)group).HanldeDrop(@object);
                break;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        return;
    }
}
