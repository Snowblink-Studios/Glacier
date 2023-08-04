#if GLACIER_UNITY && UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Glacier.Core.Events {
    [CustomEditor(typeof(EventChannelBoolSO))]
    public class EventChannelSOBoolInspector : Editor {

        private bool _param;

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            _param = GUILayout.Toggle(_param, "Boolean");

            if (GUILayout.Button("Raise Event", GUILayout.Height(30f))) {
                var channel = (EventChannelBoolSO)target;
                channel.Raise(_param);
            }
        }
    }
}
#endif
