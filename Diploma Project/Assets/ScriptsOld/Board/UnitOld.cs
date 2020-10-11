using System.Collections.Generic;
using UnityEngine;

public abstract class UnitOld : MonoBehaviour
{
    public float output;
    [SerializeField]
    bool q;
    public bool inQueue
    {
        get
        {
            return q;
        }
        set
        {
            q = value;
        }
    }

    public virtual bool AddParentsToEvent(ref Queue<UnitOld> unit)
    {
        inQueue = true;
        return true;
    }

    public abstract void Tick();

}