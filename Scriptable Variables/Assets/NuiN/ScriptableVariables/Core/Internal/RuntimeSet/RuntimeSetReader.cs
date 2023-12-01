using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NuiN.ScriptableVariables.References.Base;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class RuntimeSetReader<T> : RuntimeSetReferenceBase<T> where T : Object
{
    public ReadOnlyCollection<T> Items => runtimeSet.items.AsReadOnly();
}
