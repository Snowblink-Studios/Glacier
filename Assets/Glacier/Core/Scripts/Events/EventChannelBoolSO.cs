#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core.Events {
    [CreateAssetMenu(menuName="Glacier/Core/Events/EventChannel(Bool)", fileName="Name_Bool_EventChannel")]
    public class EventChannelBoolSO : EventChannelSO<bool> {
    }
}
#endif
