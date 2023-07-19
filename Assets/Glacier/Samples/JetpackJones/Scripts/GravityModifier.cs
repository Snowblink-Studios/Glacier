#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Samples.JetpackJones {
    public class GravityModifier : MonoBehaviour {

        [SerializeField]
        [Range(20f, 0f)]
        private float maxGravity;
        [SerializeField]
        [Range(1f, 3f)]
        private float fallMultiplier;

        private Rigidbody2D _rigidbody;
        private float _originalGravityScale;

        public void UpdateFallMultiplier(bool isFiring) {
            if (isFiring) {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Mathf.Max(_rigidbody.velocity.y, 0f));
            }
            _rigidbody.gravityScale = isFiring ? _originalGravityScale : _originalGravityScale * fallMultiplier;
        }

        private void Start() {
            _rigidbody = GetComponent<Rigidbody2D>();
            _originalGravityScale = _rigidbody.gravityScale;
        }

        private void FixedUpdate() {
            if (_rigidbody.velocity.y <= -maxGravity) {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -maxGravity);
            }
        }
    }
}
#endif
