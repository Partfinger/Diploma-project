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
    ControllerEntity current;

    private void Start()
    {
        modeText.text = (mode + 1).ToString();
        current = controllers[mode];
    }

    public void SetMode()
    {
        mode++;
        if (mode == controllers.Length)
        {
            mode = 0;
        }
        modeText.text = (mode + 1).ToString();
    }

    private void Update()
    {
        outText.text = string.Format("{0:0.0}", current.output.ToString());
        taskText.text = string.Format("{0:0.00}", current.input.output.ToString());
    }
}
