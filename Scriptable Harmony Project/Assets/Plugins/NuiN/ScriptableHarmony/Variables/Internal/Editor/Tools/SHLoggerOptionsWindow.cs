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
        [MenuItem(MENU_PATH)]
        static void ToggleLogging()
        {
            var config = Resources.Load<ScriptableHarmonyConfigSO>("ScriptableHarmony_Config");
            bool loggingEnabled = config.loggingEnabled;
            config.loggingEnabled = !loggingEnabled;
            SHLogger.loggingEnabled = loggingEnabled;
            Debug.Log("Logging: " + (loggingEnabled ? "<color=\"red\">Off</color>" : "<color=\"white\">On</color>"));
        }

        [MenuItem(MENU_PATH, true)]
        static bool ToggleLoggingValidate()
        {
            bool loggingEnabled = Resources.Load<ScriptableHarmonyConfigSO>("ScriptableHarmony_Config").loggingEnabled;
            Menu.SetChecked(MENU_PATH, loggingEnabled);
            return true;
        }
#endif
    }
}

