using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuner : MonoBehaviour
{
    [SerializeField]
    public float min, max, delta;
    public Source unit;

    public void GetDelta()
    {
        delta = max - min;
    }

    public void Prepare()
    {
        if (min > unit.start)
            unit.start = min;
        if (max < unit.start)
            unit.start = max;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -35 + 290 * (unit.start / delta)));
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
        unit.indicatorText.Perfome(unit.output);
    }
}
