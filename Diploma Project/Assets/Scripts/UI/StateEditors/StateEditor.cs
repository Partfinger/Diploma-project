using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateEditors
{
    public abstract class StateEditor : MonoBehaviour
    {
        public abstract void Show(Unit unit);

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
