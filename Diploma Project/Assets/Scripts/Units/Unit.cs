using StateEditors;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class Unit : MonoBehaviour, INameable, ISaveable
{
    public string[] editors;
    public string Name { get { return unitName; } set { unitName = value; } }
    [SerializeField]
    string unitName;

    public TabObject objectButton;

    public void Save(BinaryWriter writer)
    {
        throw new System.NotImplementedException();
    }

    public void Load(BinaryReader reader)
    {
        throw new System.NotImplementedException();
    }

    public void SelectObject()
    {
        objectButton.Select();
    }

    public abstract void Validate(List<string> logger);
}
