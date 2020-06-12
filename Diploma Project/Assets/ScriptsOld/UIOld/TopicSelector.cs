using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopicSelector : MonoBehaviour
{
    public Dropdown dropdown;
    public List<string> Elements;
    public GameObject current;
    public List<GameObject> items;

    private void Start()
    {
        dropdown.AddOptions(Elements);
        current = items[0];
    }

    public void Click(int newItem)
    {
        current = items[newItem];
    }
}
