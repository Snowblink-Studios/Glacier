using UnityEditor;

namespace Glacier.Core.Transforms {
    [CustomEditor(typeof(TransformRotator))]
    public class TransformRotatorEditor : Editor {

        public override void OnInspectorGUI() {

            EditorGUILayout.PropertyField(serializedObject.FindProperty("runOnStartup"));

            var fixedDurationProp = serializedObject.FindProperty("fixedDuration");
            EditorGUILayout.PropertyField(fixedDurationProp);

            if (fixedDurationProp.boolValue) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("duration"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("easeType"));
            }

            var specifyInitialRotationProp = serializedObject.FindProperty("specifyInitialRotation");
            EditorGUILayout.PropertyField(specifyInitialRotationProp);

            if (specifyInitialRotationProp.boolValue) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("initialRotation"));
            }

            var specifyTargetRotationProb = serializedObject.FindProperty("specifyTargetRotation");
            EditorGUILayout.PropertyField(specifyTargetRotationProb);

            if (specifyTargetRotationProb.boolValue) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("targetRotation"));
            }
            else {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("rotationStep"));
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
