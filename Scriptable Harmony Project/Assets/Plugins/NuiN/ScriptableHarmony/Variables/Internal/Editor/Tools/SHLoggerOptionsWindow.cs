using NuiN.ScriptableHarmony.Internal.Logging;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace  NuiN.ScriptableHarmony.Editor
{
    internal static class SHLoggerOptionsWindow
    {
#if UNITY_EDITOR
        const string MENU_PATH = "ScriptableHarmony/Logging/Logging Enabled";
        const string PREFS_LOGGING_KEY = "SHLoggerBool";
        
        [MenuItem(MENU_PATH)]
        static void ToggleLogging()
        {
            bool loggingEnabled = IsLoggingEnabled();
            PlayerPrefs.SetInt(PREFS_LOGGING_KEY, loggingEnabled ? 0 : 1);
            SHLogger.loggingEnabled = !loggingEnabled;
            Debug.Log("Logging: " + (loggingEnabled ? "<color=\"red\">Off</color>" : "<color=\"white\">On</color>"));
        }

        [MenuItem(MENU_PATH, true)]
        static bool ToggleLoggingValidate()
        {
            bool loggingEnabled = IsLoggingEnabled();
            Menu.SetChecked(MENU_PATH, loggingEnabled);
            return true;
        }

        public static bool IsLoggingEnabled()
        {
            return PlayerPrefs.GetInt(PREFS_LOGGING_KEY) == 1;
        }
#endif
    }
}

