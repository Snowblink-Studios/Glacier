using System;
using System.Collections.Generic;
using UnityEngine;

namespace Glacier.Core.Events {
    public abstract class EventChannelBaseSO : ScriptableObject {

        protected void Raise<L>(List<L> list, Action<L> onRaise) {
            for (int i = list.Count - 1; i >= 0; i--) {
                var listener = list[i];
                onRaise?.Invoke(listener);
            }
        }

        protected void AddListener<L>(L listener, List<L> list) where L : MonoBehaviour {
            if (list == null) {
                Debug.LogError("Possible incorrect event channel on " + listener.name);
            }
            if (listener != null && !list.Contains(listener)) {
                list.Add(listener);
            }
        }

        protected void RemoveListener<L>(L listener, List<L> list) where L : MonoBehaviour {
            if (list == null) {
                Debug.LogError("Possible incorrect event channel on " + listener.name);
            }
            if (listener != null && list.Contains(listener)) {
                list.Remove(listener);
            }
        }
    }
}
