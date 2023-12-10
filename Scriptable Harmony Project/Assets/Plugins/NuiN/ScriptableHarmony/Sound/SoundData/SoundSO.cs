using UnityEngine;

namespace NuiN.ScriptableHarmony.Sound
{
    [CreateAssetMenu(menuName = "ScriptableHarmony/Sound/Sound", fileName = "New Sound")]
    public class SoundSO : SoundBaseSO
    {
        [SerializeField] AudioClip audioClip;

        public AudioClip Clip => audioClip;
        
        protected override AudioClip GetClip() => audioClip;

        // assigns it correctly before naming, but after naming the assignment dissapears?
        /*[Conditional("UNITY_EDITOR")]
        void Awake()
        {
            // sets the field to the current selection in the editor
            if (audioClip != null || Selection.activeObject == null || Selection.activeObject is not AudioClip) return;
            audioClip = Selection.activeObject as AudioClip;
            EditorUtility.SetDirty(this);
        }*/
    }
}