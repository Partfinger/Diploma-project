using StateEditors;
using System;
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

    public abstract void Save(BinaryWriter writer);

    public abstract void Load(BinaryReader reader);

    public void SelectObject()
    {
        objectButton.Select();
    }

    public abstract void Validate(List<string> logger);
}
