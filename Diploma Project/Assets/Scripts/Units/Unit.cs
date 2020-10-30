using StateEditors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, INameable
{
    public string[] editors;
    public string Name { get { return unitName; } set { unitName = value; } }
    [SerializeField]
    string unitName;

    public TabObject objectButton;
}
