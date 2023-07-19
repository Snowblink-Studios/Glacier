#if GLACIER_UNITY
using UnityEngine;
using Glacier.Core.Events;

namespace Glacier.Samples.JetpackJones.Events {
    [CreateAssetMenu(fileName="Name_JetpackSO_EventChannel", menuName="Glacier/Samples/JetpackJones/Events/EventChannel(JetpackSO)")]
    public class OnJetpackInitializeSO : EventChannelSO<JetpackSO> {
    }
}
#endif
