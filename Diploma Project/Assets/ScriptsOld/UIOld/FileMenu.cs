using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileMenu : MonoBehaviour
{
    public void Click(int button)
    {
        Debug.Log(button);
        switch(button)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                Application.Quit();
                break;
        }
    }

    public void Save()
    {

    }

    public void ShowYesNoQuestion()
    {

    }
}
