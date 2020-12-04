using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    //[SerializeField]
    //SaveLoadMenu saveLoadMenu;
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
        TabObject newObject = AddNewTab();
        Unit newUnit = Instantiate(UnitsPrebList[id], stand);
        newObject.unit = newUnit;
        newObject.text.text = newObject.unit.Name;
        newObject.group = this;
        newUnit.objectButton = newObject;
        dropdown.SetValueWithoutNotify(0);
        OnTabSelected(newObject);
    }

    TabObject AddNewTab()
    {
        TabObject newObject = Instantiate(buttonPrefab, rect);
        tabItems.Add(newObject);
        return newObject;
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

    public override void Remove()
    {
        if (active)
        {
            tabItems.Remove(active);
            active.Remove();
            active = null;
        }
    }

    public void HanldeDrop(GameObject dropZone)
    {
        dropZone.GetComponentInParent<IInputEditor>().AddInput(captured);
        captured = null;
    }

    public void Load(BinaryReader reader)
    {
        throw new System.NotImplementedException();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(tabItems.Count);
        for (int i = 0; i < tabItems.Count; i++)
        {
            Debug.Log(tabItems[i].name.Substring(0, tabItems[i].name.Length - 7));
            writer.Write(tabItems[i].name.Substring(0, tabItems[i].name.Length - 7));
        }
        for (int i = 0; i < tabItems.Count; i++)
        {
            ((TabObject)tabItems[i]).unit.Save(writer);
        }
    }
}
