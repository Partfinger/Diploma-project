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

    public List<ControllerEntity> controllers;

    private void Start()
    {
        modeText.text = (mode + 1).ToString();
        controllers = new List<ControllerEntity>();
    }

    public void SetModeUp()
    {
        mode++;
        if (mode == controllers.Count)
        {
            mode = 0;
        }
        modeText.text = (mode + 1).ToString();
    }

    public void SetModeDown()
    {
        if (mode == 0)
        {
            mode = (byte)(controllers.Count - 1);
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
