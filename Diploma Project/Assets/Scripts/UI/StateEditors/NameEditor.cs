using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateEditors
{
    public class NameEditor : StateEditor
    {
        Unit subject;
        public InputField inputField;

        public override void Show(Unit unit)
        {
            subject = unit;
            inputField.text = subject.Name;
            gameObject.SetActive(true);
        }

        public void SetName()
        {
            if (inputField.text.Length > 0)
            {
                subject.Name = inputField.text;
                subject.objectButton.text.text = inputField.text;
            }
        }
    }

}