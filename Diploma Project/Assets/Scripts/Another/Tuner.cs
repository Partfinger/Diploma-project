using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuner : MonoBehaviour
{
    [SerializeField]
    float min, max;
    float delta;

    public Unit unit;

    private void Start()
    {
        delta = max - min;
    }


    private void OnMouseDrag()
    {
        float rotY = Input.GetAxis("Mouse X") * 60 * Mathf.Deg2Rad;
        transform.Rotate(Vector3.forward, rotY);

        Vector3 rot = transform.rotation.eulerAngles;
        if (rot.z > 325)
        {
            rot.z = 325;
            transform.rotation = Quaternion.Euler(rot);
        }
        else if (rot.z < 35)
        {
            rot.z = 35;
            transform.rotation = Quaternion.Euler(rot);
        }
        unit.output = (325 - rot.z) / 290 * delta;
    }
}
