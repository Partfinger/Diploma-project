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
    public Comparator subject;

    private void Start()
    {
        subject = parent.boardObject.GetComponent<Comparator>();
    }

    public void Add()
    {
        GameObject newO = Instantiate(inputPrefab, content);
        list.Add(newO);
        ComparatorInput input = newO.GetComponent<ComparatorInput>();
        input.panel = this;
        input.group = group;
        group.Subscribe(input);
        transform.SetAsLastSibling();
        fitter.SetLayoutVertical();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        subject.inputs.Add(null);
        subject.types.Add(false);
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

    public void SetType(int index, bool newType)
    {
        subject.types[index] = newType;
    }

    public void AddInput(int index)
    {
        subject.inputs[index] = DataClass.panelManager.captured.schemeObject.boardObject.GetComponent<Unit>();
    }

    public void Remove(int index)
    {
        list.RemoveAt(index);
        subject.inputs.RemoveAt(index);
        subject.types.RemoveAt(index);
    }
}
