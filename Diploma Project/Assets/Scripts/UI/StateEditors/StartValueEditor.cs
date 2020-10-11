using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateEditors
{
    public class StartValueEditor : StateEditor
    {
        IStartValue subject;
        [SerializeField]
        InputField start;

        public override void Show(Unit unit)
        {
            subject = unit as IStartValue;
            start.text = subject.Start.ToString();
            gameObject.SetActive(true);
        }

        public void SetStart()
        {
            subject.Start = float.Parse(start.text);
        }
    }
}
