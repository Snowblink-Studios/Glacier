#if GLACIER_UNITY && UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Glacier.Core.Events {
    [CustomEditor(typeof(EventChannelFloatSO))]
    public class EventChannelSOFloatInspector : Editor {

        private double _param;

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            _param = EditorGUILayout.DoubleField("Float", _param);

            if (GUILayout.Button("Raise Event", GUILayout.Height(30f))) {
                var channel = (EventChannelFloatSO)target;
                channel.Raise((float)_param);
            }
        }
    }
}
#endif
