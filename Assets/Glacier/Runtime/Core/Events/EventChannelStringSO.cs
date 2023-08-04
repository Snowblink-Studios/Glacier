#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core.Events {
    [CreateAssetMenu(menuName="Glacier/Core/Events/EventChannel(String)", fileName="Name_String_EventChannel")]
    public class EventChannelStringSO : EventChannelSO<string> {
    }
}
#endif
