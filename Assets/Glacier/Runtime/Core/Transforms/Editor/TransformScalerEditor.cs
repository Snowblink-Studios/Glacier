using UnityEditor;

namespace Glacier.Core.Transforms {
    [CustomEditor(typeof(TransformScaler))]
    public class TransformScalerEditor : Editor {

        public override void OnInspectorGUI() {

            EditorGUILayout.PropertyField(serializedObject.FindProperty("runOnStartup"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("duration"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("easeType"));

            var specifyInitialScaleProp = serializedObject.FindProperty("specifyInitialScale");
            EditorGUILayout.PropertyField(specifyInitialScaleProp);

            if (specifyInitialScaleProp.boolValue) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("initialScale"));
            }

            var specifyTargetScaleProb = serializedObject.FindProperty("specifyTargetScale");
            EditorGUILayout.PropertyField(specifyTargetScaleProb);

            if (specifyTargetScaleProb.boolValue) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("targetScale"));
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
