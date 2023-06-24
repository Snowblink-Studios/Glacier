#if GLACIER_UNITY
using UnityEngine;
using UnityEditor;

namespace Glacier.Core.Events {
    [CustomEditor(typeof(EventChannelSO))]
    public class EventChannelSOInspector : Editor {

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            if (GUILayout.Button("Raise Event", GUILayout.Height(30f))) {
                var channel = (EventChannelSO)target;
                channel.Raise();
            }
        }
    }
}
#endif
