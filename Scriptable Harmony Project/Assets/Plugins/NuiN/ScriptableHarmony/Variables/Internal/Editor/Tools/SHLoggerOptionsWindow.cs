using UnityEditor;
using UnityEngine;

internal static class SHLoggerOptionsWindow
{
    public const string LOGGING_BOOL_KEY = "LoggingEnabled";
    const string MENU_PATH = "ScriptableHarmony/Logging/Toggle Logging";

    [MenuItem(MENU_PATH)]
    static void ToggleLogging()
    {
        bool loggingDisabled = IsLogDisabled();
        PlayerPrefs.SetInt(LOGGING_BOOL_KEY, loggingDisabled ? 1 : -1);

        Debug.Log("Logging " + (loggingDisabled ? "<color='green'>enabled</green>" : "<color='red'>disabled</color>"));
    }

    [MenuItem(MENU_PATH, true)]
    static bool ToggleLoggingValidate()
    {
        bool loggingDisabled = IsLogDisabled();
        Menu.SetChecked(MENU_PATH, !loggingDisabled);
        return true;
    }

    static bool IsLogDisabled()
    {
        return PlayerPrefs.GetInt(LOGGING_BOOL_KEY, 1) != 1;
    }
}
