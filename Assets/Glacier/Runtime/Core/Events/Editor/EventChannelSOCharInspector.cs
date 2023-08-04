#if GLACIER_UNITY && UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Glacier.Core.Events {
    [CustomEditor(typeof(EventChannelCharSO))]
    public class EventChannelSOCharInspector : Editor {

        private string _param;

        public override void OnInspectorGUI() {
            _param = EditorGUILayout.TextField("Character", _param);

            if (GUILayout.Button("Raise Event", GUILayout.Height(30f))) {
                var channel = (EventChannelCharSO)target;
                channel.Raise(_param.Equals("") ? ' ' : _param[0]);
            }
        }
    }
}
#endif
