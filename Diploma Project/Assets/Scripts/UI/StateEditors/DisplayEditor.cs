using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateEditors
{
    public class DisplayEditor : MultiInputsEditor
    {
        public Display display;
        public TabDisplayInputsGroup group;

        public override void Show(Unit unit)
        {
            group.Show((Display)unit);
            gameObject.SetActive(true);
        }
    }
}