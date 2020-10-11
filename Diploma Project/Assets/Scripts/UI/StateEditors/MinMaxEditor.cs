using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateEditors
{
    public class MinMaxEditor : StateEditor
    {
        IMinMax subject;
        [SerializeField]
        InputField max, min;

        public override void Show(Unit unit)
        {
            subject = unit as IMinMax;
            max.text = subject.Max.ToString();
            min.text = subject.Min.ToString();
            gameObject.SetActive(true);
        }

        public void SetMax()
        {
            if (max.text.Length > 0)
                subject.Max = float.Parse(max.text);
        }

        public void SetMin()
        {
            if (min.text.Length > 0)
                subject.Min = float.Parse(min.text);
        }
    }
}
