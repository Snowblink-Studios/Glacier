#if GLACIER_UNITY
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Glacier.Core.Events;

namespace Glacier.Core.Tests {
    public class EventTests {

        [UnityTest]
        public IEnumerator EventChannel_Raise() {
            var callbackCount = 0;
            var eventChannel = ScriptableObject.CreateInstance<EventChannelSO>();
            var listener = InstantiateListener<EventChannelListener>();
            listener.AddUnityEventListener(() => {
                callbackCount ++;
            });
            listener.SetEventChannel(eventChannel);
            listener.OnEventRaised();

            yield return null;
            Assert.AreEqual(1, callbackCount);
        }

        [UnityTest]
        public IEnumerator EventChannelInt_Raise() {
            var callbackCount = 0;
            var eventChannel = ScriptableObject.CreateInstance<EventChannelIntSO>();
            var listener = InstantiateListener<EventChannelListenerInt>();
            listener.AddUnityEventListener((i) => {
                if (i == 7) {
                    callbackCount ++;
                }
            });
            listener.SetEventChannel(eventChannel);
            listener.OnEventRaised(7);

            yield return null;
            Assert.AreEqual(1, callbackCount);
        }

        [UnityTest]
        public IEnumerator EventChannelIntInt_Raise() {
            var callbackCount = 0;
            var eventChannel = ScriptableObject.CreateInstance<EventChannelIntIntSO>();
            var listener = InstantiateListener<EventChannelListenerIntInt>();
            listener.AddUnityEventListener((i, i2) => {
                if (i == 7 && i2 == 8) {
                    callbackCount ++;
                }
            });
            listener.SetEventChannel(eventChannel);
            listener.OnEventRaised(7, 8);

            yield return null;
            Assert.AreEqual(1, callbackCount);
        }

        [UnityTest]
        public IEnumerator EventChannelIntIntInt_Raise() {
            var callbackCount = 0;
            var eventChannel = ScriptableObject.CreateInstance<EventChannelIntIntIntSO>();
            var listener = InstantiateListener<EventChannelListenerIntIntInt>();
            listener.AddUnityEventListener((i, i2, i3) => {
                if (i == 7 && i2 == 8 && i3 == 9) {
                    callbackCount ++;
                }
            });
            listener.SetEventChannel(eventChannel);
            listener.OnEventRaised(7, 8, 9);

            yield return null;
            Assert.AreEqual(1, callbackCount);
        }

        [UnityTest]
        public IEnumerator EventChannelIntIntIntInt_Raise() {
            var callbackCount = 0;
            var eventChannel = ScriptableObject.CreateInstance<EventChannelIntIntIntIntSO>();
            var listener = InstantiateListener<EventChannelListenerIntIntIntInt>();
            listener.AddUnityEventListener((i, i2, i3, i4) => {
                if (i == 7 && i2 == 8 && i3 == 9 && i4 == 10) {
                    callbackCount ++;
                }
            });
            listener.SetEventChannel(eventChannel);
            listener.OnEventRaised(7, 8, 9, 10);

            yield return null;
            Assert.AreEqual(1, callbackCount);
        }

        [UnityTest]
        public IEnumerator EventChannelString_Raise() {
            var callbackCount = 0;
            var eventChannel = ScriptableObject.CreateInstance<EventChannelStringSO>();
            var listener = InstantiateListener<EventChannelListenerString>();
            listener.AddUnityEventListener((i) => {
                if (i.Equals("tEsT")) {
                    callbackCount ++;
                }
            });
            listener.SetEventChannel(eventChannel);
            listener.OnEventRaised("tEsT");

            yield return null;
            Assert.AreEqual(1, callbackCount);
        }

        [UnityTest]
        public IEnumerator EventChannelFloat_Raise() {
            var callbackCount = 0;
            var eventChannel = ScriptableObject.CreateInstance<EventChannelFloatSO>();
            var listener = InstantiateListener<EventChannelListenerFloat>();
            listener.AddUnityEventListener((i) => {
                if (i.Equals(0.5f)) {
                    callbackCount ++;
                }
            });
            listener.SetEventChannel(eventChannel);
            listener.OnEventRaised(0.5f);

            yield return null;
            Assert.AreEqual(1, callbackCount);
        }

        [UnityTest]
        public IEnumerator EventChannelChar_Raise() {
            var callbackCount = 0;
            var eventChannel = ScriptableObject.CreateInstance<EventChannelCharSO>();
            var listener = InstantiateListener<EventChannelListenerChar>();
            listener.AddUnityEventListener((i) => {
                if (i == 'G') {
                    callbackCount ++;
                }
            });
            listener.SetEventChannel(eventChannel);
            listener.OnEventRaised('G');

            yield return null;
            Assert.AreEqual(1, callbackCount);
        }

        [UnityTest]
        public IEnumerator EventChannelBool_Raise() {
            var callbackCount = 0;
            var eventChannel = ScriptableObject.CreateInstance<EventChannelBoolSO>();
            var listener = InstantiateListener<EventChannelListenerBool>();
            listener.AddUnityEventListener((i) => {
                if (i) {
                    callbackCount ++;
                }
            });
            listener.SetEventChannel(eventChannel);
            listener.OnEventRaised(true);

            yield return null;
            Assert.AreEqual(1, callbackCount);
        }

        private T InstantiateListener<T>() where T : Component {
            var g = new GameObject();
            var listener = g.AddComponent<T>();
            return listener;
        }
    }
}
#endif
