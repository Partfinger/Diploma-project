using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchemeObject : MonoBehaviour
{
    public bool haveInput;

    public GameObject propPanel, boardObject;

    public void Remove()
    {
        Destroy(propPanel);
        Destroy(boardObject);
    }
}
