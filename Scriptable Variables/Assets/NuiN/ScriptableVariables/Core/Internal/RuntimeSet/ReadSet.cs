using System;
using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableVariables.References.Base;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class ReadSet<T> : RuntimeSetReferenceBase<T> where T : Object
{
    public List<T> Items => runtimeSet.items;
}
