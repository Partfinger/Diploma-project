using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MIK51 : MonoBehaviour
{
    [SerializeField]
    byte mode;

    [SerializeField]
    Text modeText, parametrText, taskText, outText;

    public ControllerEntity[] controllers;

    private void Start()
    {
        modeText.text = (mode + 1).ToString();
    }

    public void SetModeUp()
    {
        Debug.Log("1");
        mode++;
        if (mode == controllers.Length)
        {
            mode = 0;
        }
        modeText.text = (mode + 1).ToString();
    }

    public void SetModeDown()
    {
        Debug.Log("2");
        if (mode == 0)
        {
            mode = (byte)(controllers.Length - 1);
        }
        else
        {
            mode--;
        }
        modeText.text = (mode + 1).ToString();
    }

    private void Update()
    {
        outText.text = string.Format("{0:0.0}", controllers[mode].output.ToString());
        taskText.text = string.Format("{0:0.00}", controllers[mode].input.output.ToString());
    }
}
