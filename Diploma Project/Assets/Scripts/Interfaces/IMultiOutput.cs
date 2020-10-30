using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMultiOutput
{
    List<IOutputable> Outputs { get; set; }
}
