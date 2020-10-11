using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateEditors
{
    public class ComparatorEditor : MultiInputsEditor
    {
        public TabComparatorInputsGroup group;
        public Comparator comparator;
        public override void Show(Unit unit)
        {
            group.Show(unit as Comparator);
            gameObject.SetActive(true);
        }
    }
}
