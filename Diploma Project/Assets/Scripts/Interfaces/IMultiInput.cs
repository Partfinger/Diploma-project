using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMultiInput
{
    List<IOutput> Inputs { get; set; }
}
