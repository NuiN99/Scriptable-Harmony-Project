using System;
using System.Reflection;
using UnityEditor;

public static class GizmoDisabler
{
    static MethodInfo _setIconEnabled;
    static MethodInfo SetIconEnabled => 
        _setIconEnabled ??= Assembly.GetAssembly( typeof(Editor) )
            ?.GetType( "UnityEditor.AnnotationUtility" )
            ?.GetMethod( "SetIconEnabled", BindingFlags.Static | BindingFlags.NonPublic );
 
    public static void SetGizmoIconEnabled( Type type, bool on ) {
        if( SetIconEnabled == null ) return;
        const int monoBehaviorClassID = 114; // https://docs.unity3d.com/Manual/ClassIDReference.html
        SetIconEnabled.Invoke( null, new object[] { monoBehaviorClassID, type.Name, on ? 1 : 0 } );
    }
}
