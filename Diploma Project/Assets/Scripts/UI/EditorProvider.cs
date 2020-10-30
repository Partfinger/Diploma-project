using StateEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorProvider : MonoBehaviour
{
    public Transform manager;

    public List<StateEditor> EditorPrefabs;

    List<StateEditor> editorsList = new List<StateEditor>();
    Dictionary<string, StateEditor> editors = new Dictionary<string, StateEditor>();

    [SerializeField]
    ColorPickerEditor colorEditor;
    public IColorSetable colorSetable;

    private void Start()
    {
        TabObject.provider = this;
        for (int i = 0; i < EditorPrefabs.Count; i++)
        {
            StateEditor current = Instantiate(EditorPrefabs[i], manager.transform);
            editors.Add(current.name.Substring(0, current.name.Length - 7), current);
            current.gameObject.SetActive(false);
            editorsList.Add(current);
        }
        TabDisplayInputsGroup.editorProvider = this;
        colorEditor.provider = this;
    }

    public StateEditor Get(string key)
    {
        try
        {
            return editors[key];
        }
        catch
        {
            throw new Exception($"There is not this key: {key}");
        }
    }

    public void HideEditors()
    {
        foreach(StateEditor editor in editorsList)
        {
            editor.Close();
        }
    }

    public void ShowColorPicker(Color startColor)
    {
        colorEditor.Show(startColor);
    }
}
