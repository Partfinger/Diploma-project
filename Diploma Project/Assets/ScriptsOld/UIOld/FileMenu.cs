using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class FileMenu : MonoBehaviour
{
    public Dropdown dd;
    public void Click(int button)
    {
        switch(button)
        {
            case 1:
                DataClass.objectManager.ClearAll();
                break;
            case 2:
                Load();
                break;
            case 3:
                Save();
                break;
            case 5:
                Application.Quit();
                break;
        }
        dd.SetValueWithoutNotify(0);
    }

    void Save()
    {
        DataClass.saveLoadMenu.Open(true);
    }

    void Load()
    {
        DataClass.saveLoadMenu.Open(false);
    }
}
