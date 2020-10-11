using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateEditors
{
    public class MultiInputsEditor : StateEditor
    {
        IMultiInput subject;

        public override void Show(Unit unit)
        {
            subject = unit as IMultiInput;
            gameObject.SetActive(true);
        }
    }
}