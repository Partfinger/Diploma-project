using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateEditors
{
    public class TabComparatorInputsGroup : TabGroup
    {
        public ComparatorEditor editor;
        public TabComparatorInput inputPrefab;
        public RectTransform rect;
        [SerializeField]
        int Count { get { return tabItems.Count; } }

        internal void Show(Comparator comparator)
        {
            if (editor.comparator)
            {
                if (editor.comparator != comparator)
                {
                    RemoveTabs();
                }
                else
                {
                    return;
                }
            }
            editor.comparator = comparator;
            for (int i = 0; i < comparator.inputs.Count; i++)
            {
                AddPrefab();
                UpdateData(i);
            }
        }

        public override void Subscribe(TabItem item)
        {
            base.Subscribe(item);
            Add();
            item.gameObject.transform.SetAsLastSibling();
        }

        public void Add()
        {
            TabComparatorInput input = Instantiate(inputPrefab, transform);
            input.group = this;
            tabItems.Add(input);
            editor.comparator.inputs.Add(null);
            editor.comparator.types.Add(false);
            LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        }

        void AddPrefab()
        {
            TabComparatorInput input = Instantiate(inputPrefab, transform);
            input.group = this;
            tabItems.Add(input);

            LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        }

        void UpdateData(int index)
        {
            TabComparatorInput input = (TabComparatorInput)tabItems[index];
            input.SetType(editor.comparator.types[index]);
            if (editor.comparator.inputs[index] != null)
                input.SetInput(((Unit)editor.comparator.inputs[index]).Name);
        }

        public override void Remove(TabItem item)
        {
            int index = tabItems.IndexOf(item);
            editor.comparator.inputs.RemoveAt(index);
            editor.comparator.types.RemoveAt(index);
            tabItems.RemoveAt(index);
        }

        public override void Remove()
        {
            int index = tabItems.IndexOf(active);
            editor.comparator.inputs.RemoveAt(index);
            editor.comparator.types.RemoveAt(index);
            tabItems.RemoveAt(index);
        }

        public void SetInput(TabComparatorInput item, TabObject tabObject)
        {
            int index = tabItems.IndexOf(item);
            editor.comparator.inputs[index] = ((IOutput)tabObject.unit);
        }

        public void SetInputType(TabComparatorInput item)
        {
            int index = tabItems.IndexOf(item);
            editor.comparator.types[index] = !editor.comparator.types[index];
        }

        public void SetInputType(TabComparatorInput item, bool newType)
        {
            int index = tabItems.IndexOf(item);
            editor.comparator.types[index] = newType;
        }
    }
}
