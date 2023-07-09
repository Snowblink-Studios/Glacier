#if GLACIER_UNITY && UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Glacier.Core.Events {
    [CustomEditor(typeof(EventChannelIntSO))]
    public class EventChannelSOIntInspector : Editor {

        private int _param;

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            _param = EditorGUILayout.IntField("Integer", _param);

            if (GUILayout.Button("Raise Event", GUILayout.Height(30f))) {
                var channel = (EventChannelIntSO)target;
                channel.Raise(_param);
            }
        }
    }
}
#endif
