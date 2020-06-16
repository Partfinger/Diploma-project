using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchemeObject : MonoBehaviour
{
    public bool haveInput;
    [SerializeField]
    SchemeObject input;

    public SchemeObject Input
    {
        get
        {
            return input;
        }
        set
        {
            input = value;
            EntryUnit unit = boardObject.GetComponent<EntryUnit>();
            unit.input = 
                input.boardObject.GetComponent<Unit>();
        }
    }


    public GameObject propPanel, boardObject;

    public void Remove()
    {
        Destroy(propPanel);
        Destroy(boardObject);
    }
}
