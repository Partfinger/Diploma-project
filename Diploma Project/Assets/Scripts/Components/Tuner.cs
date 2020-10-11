using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuner : MonoBehaviour, IMovable
{
    [SerializeField]
    float delta, current;
    public ITunable subject;
    [SerializeField]
    Indicator indicator;

    private void Start()
    {
        subject = transform.parent.GetComponent<ITunable>();
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
        current = (325 - rot.z) / 290 * delta;
        subject.Tune(current);
        indicator.Set(current);
    }

    public void StartSimulation()
    {
        var subj = subject as IMinMax;
        delta = subj.Max - subj.Min;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -35 + 290 * ((subject as IOutput).Output / delta)));
        GetComponent<Collider>().enabled = true;
    }

    public void StopSimulation()
    {
        GetComponent<Collider>().enabled = false;
    }
}
