#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Samples.JetpackJones {
    public class MainCharacter : MonoBehaviour {

        [SerializeField]
        private Transform jetpackRoot;
        [SerializeField]
        private new Rigidbody2D rigidbody;

        private Jetpack _jetpack;

        public void InitializeJetpack(JetpackSO jetpackSettings) {
            _jetpack = jetpackSettings.InstantiatePrefab();
            _jetpack.transform.SetParent(jetpackRoot);
            _jetpack.transform.localPosition = Vector3.zero;
            _jetpack.Initialize(jetpackSettings, rigidbody);
        }
    }
}
#endif
