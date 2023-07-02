using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Glacier.Samples.JetpackJones {
    public class LevelSceneManager : MonoBehaviour {

        [SerializeField]
        private UnityEvent onInitializeJetpack;

        private IEnumerator Start() {
            yield return new WaitForSeconds(0.05f);
            onInitializeJetpack?.Invoke();
        }
    }
}
