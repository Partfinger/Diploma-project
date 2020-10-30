using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMultiInput
{
    List<IOutputable> Inputs { get; set; }
}
