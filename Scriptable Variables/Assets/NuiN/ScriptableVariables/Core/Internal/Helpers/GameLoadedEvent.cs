using System;
using UnityEngine;

namespace NuiN.ScriptableVariables.Internal.Helpers
{
    internal static class GameLoadedEvent
    {
        public static event Action OnGameLoaded;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void GameLoaded() => OnGameLoaded?.Invoke();
    }
}

