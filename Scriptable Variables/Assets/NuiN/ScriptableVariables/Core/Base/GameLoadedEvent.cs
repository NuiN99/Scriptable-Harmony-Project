using System;
using UnityEngine;

namespace NuiN.ScriptableVaraibles.Lifetime
{
    internal class GameLoadedEvent : MonoBehaviour
    {
        public static event Action OnGameLoaded;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void GameLoaded() => OnGameLoaded?.Invoke();
    }
}

