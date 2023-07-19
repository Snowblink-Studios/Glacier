#if GLACIER_UNITY
using UnityEngine;
using UnityEngine.Events;

namespace Glacier.Samples.JetpackJones {
    public class Jetpack : MonoBehaviour {

        [SerializeField]
        private UnityEvent onFire;

        private JetpackSO _settings;
        private Rigidbody2D _rigidBody;
        private bool _isFiring = false;
        private float _firingCooldownMax = 0f;
        private float _firingCooldown = 0f;

        public void ToggleFiring(bool isFiring) => _isFiring = isFiring;

        public void Initialize(JetpackSO settings, Rigidbody2D rigidbody) {
            _settings = settings;
            _rigidBody = rigidbody;
            _firingCooldownMax = 1f / settings.FireRate;
            _firingCooldown = 0f;
        }

        private void FixedUpdate() {
            if (_isFiring) {
                _firingCooldown = Mathf.Max(_firingCooldown - Time.deltaTime, 0f);
                if (_firingCooldown.Equals(0f)) {
                    Fire();
                    _firingCooldown = _firingCooldownMax;
                }
            }
        }

        private void Fire() {
            _rigidBody.AddForce(Vector2.up * _settings.FirePower, ForceMode2D.Impulse);
            onFire?.Invoke();
        }
    }
}
#endif
