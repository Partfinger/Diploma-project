using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComparatorEditorPanel : EditedPanel
{
    public GameObject inputPrefab;
    public Transform content;
    public List<GameObject> list;
    public TabGroup group;
    public RectTransform rect;

    private void Start()
    {
        ComparatorInput.panel = this;
    }

    public void Add()
    {
        GameObject newO = Instantiate(inputPrefab, content);
        list.Add(newO);
        ComparatorInput input = newO.GetComponent<ComparatorInput>();
        input.group = group;
        group.Subscribe(input);
        group.OnTabSelected(input);
        transform.SetAsLastSibling();
        fitter.SetLayoutVertical();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
    }

    public override void AddInput(GameObject dropZone)
    {
        foreach (TabButton tab in group.tabButtons)
        {
            if (tab.gameObject == dropZone)
            {
                ((TabComparatorInputsGroup)group).SetInput((ComparatorInput)tab, DataClass.panelManager.captured);
                break;
            }
        }
    }

    public void Remove(int index)
    {
        list.RemoveAt(index);
    }
}
