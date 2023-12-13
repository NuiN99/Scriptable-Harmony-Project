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
        public static void Log<T>(string message, ScriptableObjectBaseSO<T> obj)
        {
            bool loggingDisabled = PlayerPrefs.GetInt(SHLoggerOptionsWindow.LOGGING_BOOL_KEY, 1) != 1;
            
            if (loggingDisabled || !obj.LogEvents) return;
            Debug.Log($"{message} | {obj.name}", obj);
        }

        [Conditional("UNITY_EDITOR")] [Conditional("DEVELOPMENT_BUILD")]
        static void LogEvent<T>(string eventName, string contents, ScriptableObjectBaseSO<T> obj)
        {
            Log($"Event: <color='orange'>{eventName}</color> | {contents}", obj);
        }

        [Conditional("UNITY_EDITOR")] [Conditional("DEVELOPMENT_BUILD")]
        public static void LogSetEvent<T>(string eventName, T from, T to, ScriptableObjectBaseSO<T> obj)
        {
            string contents = $"From: <color='red'>{from}</color>, To: <color='white'>{to}</color>";
            LogEvent(eventName, contents, obj);
        }
    }
}

