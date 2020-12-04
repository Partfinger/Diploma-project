using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateEditors
{
    public class TabComparatorInputsGroup : TabInputsGroup
    {
        Comparator comparator;

        public override void Show(Unit unit)
        {
            subject = unit as IMultiInput;
            if (comparator == unit as Comparator)
            {
                return;
            }
            RemoveTabs();
            comparator = unit as Comparator;
            for (int i = 0; i < comparator.inputs.Count; i++)
            {
                AddPrefab();
                UpdateData(i);
            }
        }

        public override void Add()
        {
            base.AddPrefab();
            comparator.inputs.Add(null);
            comparator.types.Add(false);
        }

        protected override void UpdateData(int index)
        {
            TabComparatorInput input = (TabComparatorInput)tabItems[index];
            input.SetType(comparator.types[index]);
            if (comparator.inputs[index] != null)
                input.SetInput(((Unit)comparator.inputs[index]).Name);
        }

        public override void Remove(TabItem item)
        {
            int index = tabItems.IndexOf(item);
            comparator.inputs.RemoveAt(index);
            comparator.types.RemoveAt(index);
            tabItems.RemoveAt(index);
        }

        public void SetInputType(TabComparatorInput item)
        {
            int index = tabItems.IndexOf(item);
            comparator.types[index] = !comparator.types[index];
        }

        public void SetInputType(TabComparatorInput item, bool newType)
        {
            int index = tabItems.IndexOf(item);
            comparator.types[index] = newType;
        }
    }
}
