using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateEditors
{
    public class SingleInputEditor : StateEditor, IInputEditor
    {
        IInputable subject;
        public Text text;

        public override void Show(Unit unit)
        {
            subject = unit as IInputable;
            gameObject.SetActive(true);
            if (subject.Input != null) 
                text.text = ((Unit)subject.Input).Name;
        }

        public void AddInput(TabObject @object)
        {
            subject.Input = (IOutputable)@object.unit;
            text.text = @object.unit.Name;
        }
    }
}
