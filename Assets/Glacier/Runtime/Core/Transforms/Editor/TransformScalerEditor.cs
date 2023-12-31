using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace Glacier.Core.Transforms {
    [CustomEditor(typeof(TransformScaler))]
    public class TransformScalerEditor : Editor {

        public override void OnInspectorGUI() {

            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((MonoBehaviour)target), typeof(MonoBehaviour), false);
            EditorGUI.EndDisabledGroup();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("runOnStartup"));

            var specifyInitialScaleProp = serializedObject.FindProperty("specifyInitialScale");
            EditorGUILayout.PropertyField(specifyInitialScaleProp);

            if (specifyInitialScaleProp.boolValue) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("initialScale"));
            }

            var fixedDurationProp = serializedObject.FindProperty("fixedDuration");
            EditorGUILayout.PropertyField(fixedDurationProp);

            if (fixedDurationProp.boolValue) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("duration"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("easeType"));

                var specifyTargetScaleProp = serializedObject.FindProperty("specifyTargetScale");
                EditorGUILayout.PropertyField(specifyTargetScaleProp);

                if (specifyTargetScaleProp.boolValue) {
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("targetScale"));
                }
                else {
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("scaleStep"));
                }
            }
            else {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("scaleStep"));
            }

            var targetSelfProp = serializedObject.FindProperty("targetSelf");
            EditorGUILayout.PropertyField(targetSelfProp);

            if (!targetSelfProp.boolValue) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("targetObject"));
            }

            EditorGUILayout.Space(20f);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onFinished"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
