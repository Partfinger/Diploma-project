using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorPanelManager : MonoBehaviour
{
    public GameObject inputPanel, specialPanel, QuestionPanel, back;
    public ControllerPathSelector QuestionControllerPathPanel;
    public Text questionText;
    public EditorObjectManager manager;
    public EditedPanel panel;
    public TabSchemeObject captured;
    public bool itIsController;
    GameObject dz;

    private void Start()
    {
        EditedPanel.fitter = GetComponent<ContentSizeFitter>();
        DataClass.panelManager = this;
        EditedPanel.layoutGroup = GetComponent<LayoutGroup>();
    }

    public virtual void AddInput(GameObject dropZone)
    {
        if (!panel.haveSeveralInputs || dropZone.name == "Input Panel")
        {
            if (itIsController)
            {
                back.SetActive(true);
                dz = dropZone;
                QuestionControllerPathPanel.Show();
            }
            else
            {
                panel.parent.Input = captured.schemeObject;
                inputPanel.transform.GetChild(1).GetComponentInChildren<Text>().text = captured.schemeObject.name;
                captured = null;
            }
        }
        else
        {
            if (itIsController)
            {
                back.SetActive(true);
                dz = dropZone;
                QuestionControllerPathPanel.Show();
            }
            else
            {
                panel.AddInput(dropZone);
                captured = null;
            }
        }
    }

    public void AddInput(int id)
    {
        MIKEditorPanel mep = captured.schemeObject.propPanel.GetComponent<MIKEditorPanel>();
        captured = mep.controlPaths[id];
        if (dz.name == "Input Panel")
        {
            panel.parent.Input = captured.schemeObject;
            inputPanel.transform.GetChild(1).GetComponentInChildren<Text>().text = captured.schemeObject.name;
        }
        else
        {
            panel.AddInput(dz);
        }
        dz = null;
        captured = null;
        back.SetActive(false);
    }

    public void CancleSelector()
    {
        dz = null;
        captured = null;
        back.SetActive(false);
    }

    enum QuestionMode { none, delete}

    QuestionMode mode = QuestionMode.none;

    public void ResetIt()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Remove()
    {
        if (manager.group.active)
        {
            mode = QuestionMode.delete;
            //ShowQuestion("Ви впевнені?");
            manager.RemoveElement();
        }
    }

    public void ShowQuestion(string q)
    {
        questionText.text = q;
        QuestionPanel.SetActive(true);
    }

    public void Confirm()
    {
        switch (mode)
        {
            case QuestionMode.delete:
                manager.RemoveElement();
                break;
        }
        QuestionPanel.SetActive(false);
    }

    public void Cancle()
    {
        mode = QuestionMode.none;
        QuestionPanel.SetActive(false);
    }
}
