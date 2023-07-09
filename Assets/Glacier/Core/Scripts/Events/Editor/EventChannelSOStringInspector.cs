#if GLACIER_UNITY && UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Glacier.Core.Events {
    [CustomEditor(typeof(EventChannelStringSO))]
    public class EventChannelSOStringInspector : Editor {

        private string _param;

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            _param = EditorGUILayout.TextField("String", _param);

            if (GUILayout.Button("Raise Event", GUILayout.Height(30f))) {
                var channel = (EventChannelStringSO)target;
                channel.Raise(_param);
            }
        }
    }
}
#endif
