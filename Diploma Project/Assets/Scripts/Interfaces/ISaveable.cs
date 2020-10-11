using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public interface ISaveable
{
    void Save(BinaryWriter writer);

    void Load(BinaryReader reader);
}
