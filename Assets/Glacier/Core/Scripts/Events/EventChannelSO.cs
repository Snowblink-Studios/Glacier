#if GLACIER_UNITY
using System.Collections.Generic;
using UnityEngine;

namespace Glacier.Core.Events {
    [CreateAssetMenu(menuName="Glacier/Core/Events/EventChannel", fileName="EventChannel")]
    public class EventChannelSO : EventChannelBaseSO {

        private List<EventChannelListener> _listeners = new();

        public void AddListener(EventChannelListener listener) => AddListener(listener, _listeners);
        public void RemoveListener(EventChannelListener listener) => RemoveListener(listener, _listeners);

        public void Raise() {
            Raise(_listeners, (l) => l.OnEventRaised());
        }
    }
}
#endif
