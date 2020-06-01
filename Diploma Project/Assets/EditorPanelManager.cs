using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorPanelManager : MonoBehaviour
{
    public GameObject inputPanel, specialPanel, deletePanel;
    public GameObject QuestionPanel;
    public Text questionText;
    public EditorObjectManager manager;
    public EditedPanel panel;

    enum QuestionMode { none, delete}

    QuestionMode mode = QuestionMode.none;

    public void Apply()
    {
        panel.Apply();
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
