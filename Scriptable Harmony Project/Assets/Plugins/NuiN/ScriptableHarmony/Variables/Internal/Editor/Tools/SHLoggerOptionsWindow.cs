using NuiN.ScriptableHarmony.Internal.Logging;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace  NuiN.ScriptableHarmony.Editor
{
    internal static class SHLoggerOptionsWindow
    {
#if UNITY_EDITOR
        const string MENU_PATH = "ScriptableHarmony/Logging/";

        const string LOGGING_PATH_SUFFIX = "Logging Enabled";
        const string PREFS_LOGGING_KEY = "SHLoggerBool";

        const string VARIABLE_PATH_SUFFIX = "Individual Objects/Scriptable Variable";
        const string LISTVARIABLE_PATH_SUFFIX = "Individual Objects/Scriptable List Variable";
        const string RUNTIMESET_PATH_SUFFIX = "Individual Objects/Runtime Set";
        const string RUNTIMESINGLE_PATH_SUFFIX = "Individual Objects/Runtime Single";
        
        const string PREFS_VARIABLE_LOGGING_KEY = "SHLoggerVariableBool";
        const string PREFS_LISTVARIABLE_LOGGING_KEY = "SHLoggerListVariableBool";
        const string PREFS_RUNTIMESET_LOGGING_KEY = "SHLoggerRuntimeSetBool";
        const string PREFS_RUNTIMESINGLE_LOGGING_KEY = "SHLoggeRuntimeSingleBool";

        static bool ToggleLoggingOption(bool loggingEnabled, string prefsKey, string logMessage)
        {
            PlayerPrefs.SetInt(prefsKey, loggingEnabled ? 0 : 1);
            PlayerPrefs.Save();
            Debug.Log(logMessage + (loggingEnabled ? "<color=\"red\">Off</color>" : "<color=\"white\">On</color>"));

            return !loggingEnabled;
        }
        
        [MenuItem(MENU_PATH + LOGGING_PATH_SUFFIX)]
        static void ToggleLogging()
        {
            SHLogger.logging = ToggleLoggingOption(IsLoggingEnabled(), PREFS_LOGGING_KEY, "Logging: ");
        }
        [MenuItem(MENU_PATH + LOGGING_PATH_SUFFIX, true)]
        static bool ToggleLoggingValidate()
        {
            Menu.SetChecked(MENU_PATH + LOGGING_PATH_SUFFIX, IsLoggingEnabled());
            return true;
        }
        
        [MenuItem(MENU_PATH + VARIABLE_PATH_SUFFIX)]
        static void ToggleVariableLogging()
        {
            SHLogger.variableLogging = ToggleLoggingOption(IsVariableLoggingEnabled(), PREFS_VARIABLE_LOGGING_KEY, "Scriptable Variable Logs: ");
        }
        [MenuItem(MENU_PATH + VARIABLE_PATH_SUFFIX, true)]
        static bool ToggleVariableLoggingValidate()
        {
            Menu.SetChecked(MENU_PATH + VARIABLE_PATH_SUFFIX, IsVariableLoggingEnabled());
            return true;
        }
        
        [MenuItem(MENU_PATH + LISTVARIABLE_PATH_SUFFIX)]
        static void ToggleListVariableLogging()
        {
            SHLogger.listVariableLogging = ToggleLoggingOption(IsListVariableLoggingEnabled(), PREFS_LISTVARIABLE_LOGGING_KEY, "Scriptable List Variable Logs: ");
        }
        [MenuItem(MENU_PATH + LISTVARIABLE_PATH_SUFFIX, true)]
        static bool ToggleListVariableLoggingValidate()
        {
            Menu.SetChecked(MENU_PATH + LISTVARIABLE_PATH_SUFFIX, IsListVariableLoggingEnabled());
            return true;
        }
        
        [MenuItem(MENU_PATH + RUNTIMESET_PATH_SUFFIX)]
        static void ToggleRuntimeSetLogging()
        {
            SHLogger.runtimeSetLogging = ToggleLoggingOption(IsRuntimeSetLoggingEnabled(), PREFS_RUNTIMESET_LOGGING_KEY, "Runtime Set Logs: ");
        }
        [MenuItem(MENU_PATH + RUNTIMESET_PATH_SUFFIX, true)]
        static bool ToggleRuntimeSetLoggingValidate()
        {
            Menu.SetChecked(MENU_PATH + RUNTIMESET_PATH_SUFFIX, IsRuntimeSetLoggingEnabled());
            return true;
        }
        
        [MenuItem(MENU_PATH + RUNTIMESINGLE_PATH_SUFFIX)]
        static void ToggleRuntimeSingleLogging()
        {
            SHLogger.runtimeSetLogging = ToggleLoggingOption(IsRuntimeSingleLoggingEnabled(), PREFS_RUNTIMESINGLE_LOGGING_KEY, "Runtime Single Logs: ");
        }
        [MenuItem(MENU_PATH + RUNTIMESINGLE_PATH_SUFFIX, true)]
        static bool ToggleRuntimeSingleLoggingValidate()
        {
            Menu.SetChecked(MENU_PATH + RUNTIMESINGLE_PATH_SUFFIX, IsRuntimeSingleLoggingEnabled());
            return true;
        }

        static bool LoggingCheck(string prefsKey)
        {
            if (PlayerPrefs.HasKey(prefsKey))
            {
                return PlayerPrefs.GetInt(prefsKey) == 1;
            }

            PlayerPrefs.SetInt(prefsKey, 1);
            PlayerPrefs.Save();
            return true;
        }

        public static bool IsLoggingEnabled() => LoggingCheck(PREFS_LOGGING_KEY);
        public static bool IsVariableLoggingEnabled() => LoggingCheck(PREFS_VARIABLE_LOGGING_KEY);
        public static bool IsListVariableLoggingEnabled() => LoggingCheck(PREFS_LISTVARIABLE_LOGGING_KEY);
        public static bool IsRuntimeSetLoggingEnabled() => LoggingCheck(PREFS_RUNTIMESET_LOGGING_KEY);
        public static bool IsRuntimeSingleLoggingEnabled() => LoggingCheck(PREFS_RUNTIMESINGLE_LOGGING_KEY);
#endif
    }
}

