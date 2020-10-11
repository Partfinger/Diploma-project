using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabObjectManager : TabGroup
{
    [SerializeField]
    List<Unit> UnitsPrebList;
    [SerializeField]
    TabObject buttonPrefab;
    [SerializeField]
    RectTransform rect;
    [SerializeField]
    Dropdown dropdown;
    [SerializeField]
    Transform stand;
    [SerializeField]
    SaveLoadMenu saveLoadMenu;
    [SerializeField]
    EditorProvider editorProvider;
    public Color tabIdle, tabActive;

    public TabObject captured;
    public IInputEditor activeInputEditor;

    private void Start()
    {
        List<string> unitsNameList = new List<string>();
        unitsNameList.Add("Додати");
        for (int i = 0; i < UnitsPrebList.Count; i++)
        {
            unitsNameList.Add(UnitsPrebList[i].Name);
        }
        dropdown.AddOptions(unitsNameList);
    }

    public void AddNewObject(int id)
    {
        id--;
        TabObject newObject = Instantiate(buttonPrefab, rect);
        tabItems.Add(newObject);
        Unit newUnit = Instantiate(UnitsPrebList[id], stand);
        newObject.unit = newUnit;
        newObject.text.text = newObject.unit.Name;
        newObject.group = this;
        dropdown.SetValueWithoutNotify(0);
        OnTabSelected(newObject);
    }

    public override void OnTabSelected(TabItem item)
    {
        if (active == item)
        {
            return;
        }
        else if (active)
        {
            active.Exit();
            ((TabButton)active).background.color = tabIdle;
        }
        active = item;
        ((TabButton)item).background.color = tabActive;
        active.Select();
    }

    public override void Remove(TabItem item)
    {
        throw new System.NotImplementedException();
    }

    public void HanldeDrop(GameObject dropZone)
    {
        dropZone.GetComponentInParent<IInputEditor>().AddInput(captured);
        captured = null;
    }
}
