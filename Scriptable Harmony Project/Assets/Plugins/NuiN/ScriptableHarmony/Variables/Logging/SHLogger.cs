using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using NuiN.ScriptableHarmony.Base;
using NuiN.ScriptableHarmony.Editor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace NuiN.ScriptableHarmony.Internal.Logging
{
    internal static class SHLogger
    {
        public static bool loggingEnabled;

        [RuntimeInitializeOnLoadMethod]
        static void CheckLoggingState()
        {
            loggingEnabled = SHLoggerOptionsWindow.IsLoggingEnabled();
        }
        
        [Conditional("UNITY_EDITOR")] [Conditional("DEVELOPMENT_BUILD")]
        public static void Log<T>(string message, ScriptableObjectBaseSO<T> obj)
        {
            if (!loggingEnabled || !obj.LogEvents) return;
            Debug.Log($"{message} | {obj.name}", obj);
        }

        [Conditional("UNITY_EDITOR")] [Conditional("DEVELOPMENT_BUILD")]
        static void LogAction<T>(string eventName, string contents, bool invokedAction, ScriptableObjectBaseSO<T> obj)
        {
            string suffix = invokedAction ? "" : "(No Invoke)";
            Log($"Event: <color='orange'>{eventName} {suffix}</color> | {contents}", obj);
        }

        [Conditional("UNITY_EDITOR")] [Conditional("DEVELOPMENT_BUILD")]
        public static void LogVariableSet<T>(string eventName, T from, T to, bool invokedAction, ScriptableObjectBaseSO<T> obj)
        {
            string contents = $"From: <color='red'>{from}</color>, To: <color='white'>{to}</color>";
            LogAction(eventName, contents, invokedAction, obj);
        }
        
        [Conditional("UNITY_EDITOR")] [Conditional("DEVELOPMENT_BUILD")]
        public static void LogListVariableAdd<T>(string eventName, T added, bool invokedAction, ScriptableObjectBaseSO<T> obj)
        {
            string contents = $"Added: <color='white'>{added}</color>";
            LogAction(eventName, contents, invokedAction, obj);
        }
    }
}

