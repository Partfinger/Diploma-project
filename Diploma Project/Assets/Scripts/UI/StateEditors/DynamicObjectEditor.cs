using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace StateEditors
{
    public class DynamicObjectEditor : StateEditor
    {
        public InputField num, denum;
        public Toggle check;
        DynamicUnit subject;

        public override void Show(Unit unit)
        {
            gameObject.SetActive(true);
            if (subject)
            {
                if (subject == unit as DynamicUnit)
                    return;
            }
            subject = unit as DynamicUnit;
            UpdateInputLines();
        }

        void UpdateInputLines()
        {
            for (int i = 0; i < subject.function.numerator.Length; i++)
            {
                num.text += subject.function.numerator[i] + " ";
            }
            for (int i = 0; i < subject.function.denumerator.Length; i++)
            {
                denum.text += subject.function.denumerator[i] + " ";
            }
            if (subject.function is ZForm)
            {
                check.isOn = true;
            }
        }

        public void SetN()
        {
            subject.function.Numerator = Handle(num.text);
        }

        public void SetD()
        {
            subject.function.Denumerator = Handle(denum.text);
        }

        float[] Handle(string s)
        {
            string[] strings = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            float[] array = new float[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                array[i] = float.Parse(Regex.Replace(strings[i], "\\.", ","));
            }
            return array;


            /*
               isDiscrete = toggle;
        TransferFunction tf;
        if (isDiscrete)
        {
            Destroy(unit.funct);
            tf = unit.gameObject.AddComponent<ZForm>();
            tf.numerator = u;
            tf.denumerator = y;
            unit.funct = tf;
            unit.funct.Recalculate();
            //inputDt.SetActive(true);
        }
        else
        {
            Destroy(unit.funct);
            tf = unit.gameObject.AddComponent<SForm>();
            tf.numerator = u;
            tf.denumerator = y;
            unit.funct = tf;
            unit.funct.Recalculate();
            //inputDt.SetActive(false);
        }
    }
            */
        }
    }
}