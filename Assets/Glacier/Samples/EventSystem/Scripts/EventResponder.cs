#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Sample.EventSystem {
    public class EventResponder : MonoBehaviour {

        public void DisplayText(string text) {
            Debug.Log("Text: " + text);
        }

        public void DisplayInt(int num) {
            Debug.Log("Int: " + num);
        }
    }
}
#endif
