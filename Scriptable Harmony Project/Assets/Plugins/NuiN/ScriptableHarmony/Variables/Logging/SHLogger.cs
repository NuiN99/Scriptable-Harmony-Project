using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using NuiN.ScriptableHarmony.Base;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace NuiN.ScriptableHarmony.Internal.Logging
{
    internal static class SHLogger
    {
        [Conditional("UNITY_EDITOR")] [Conditional("DEVELOPMENT_BUILD")]
        public static void LogEvent<T>(string eventName, string details, ScriptableObjectBaseSO<T> obj)
        {
            if (!obj.LogEvents) return;
            string message = $"<color='orange'>{eventName} Event</color> | {details} | {obj.name}";
            Debug.Log(message, obj);
        }
    }
}

