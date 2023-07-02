using UnityEngine;

namespace Glacier.Samples.JetpackJones {
    [CreateAssetMenu(fileName="JetpackSO", menuName="Glacier/Samples/JetpackJones/JetpackSO")]
    public class JetpackSO : ScriptableObject {

        [SerializeField]
        private Jetpack jetpackPrefab;
        [SerializeField]
        [Range(0f, 20f)]
        private float firePower = 10f;
        [SerializeField]
        [Range(5f, 20f)]
        private float fireRate = 2f;

        public float FirePower => firePower;
        public float FireRate => fireRate;

        public Jetpack InstantiatePrefab() => Instantiate(jetpackPrefab, null, false);
    }
}
