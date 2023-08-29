using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace Glacier.Core.Transforms {
    public class TransformScaler : MonoBehaviour {

        [SerializeField]
        private bool runOnStartup;

        [SerializeField]
        private bool specifyInitialScale = false;
        [SerializeField]
        private Vector3 initialScale;

        [SerializeField]
        private bool specifyTargetScale = true;
        [SerializeField]
        private Vector3 targetScale;
        [SerializeField]
        private Vector3 scaleStep;
        
        [SerializeField]
        private float duration;

        [SerializeField]
        private bool targetSelf = true;
        [SerializeField]
        private Transform targetObject;

        [SerializeField]
        private Ease easeType = Ease.Linear;

        [SerializeField]
        private UnityEvent onFinished;

        public UnityEvent OnFinished => onFinished;

        private Transform _targetObject;
        private float _time;
        private bool _isRunning = false;
        private Tween _tween;

        public void Stop() {
            StopAllCoroutines();
            _tween?.Kill();
        }

        public void Scale() {
            if (!enabled) {
                return;
            }
            if (specifyInitialScale) {
                _targetObject.localScale = initialScale;
            }
            Scale(null);
        }

        public void Scale(float from, float to) {
            if (!enabled) {
                return;
            }

            _targetObject.localScale = Vector3.one * from;
            StartCoroutine(DoScale(_targetObject, Vector3.one * to, duration));
        }

        public void Scale(Action onFinished) {
            if (!enabled) {
                return;
            }

            if (specifyTargetScale) {
                StartCoroutine(DoScale(_targetObject, targetScale, duration));
            }
            else {
                _isRunning = true;
                _time = duration;
            }
        }

        private void Start() {
            if (!enabled) {
                return;
            }

            _targetObject = targetSelf ? transform : targetObject;

            if (runOnStartup) {
                Scale();
            }
        }

        private void Update() {
            if (!enabled) {
                return;
            }

            if (_isRunning) {
                _targetObject.localScale += scaleStep * Mathf.Min(Time.deltaTime, 1f / 30f);
                _time = Mathf.Max(_time - Time.deltaTime, 0f);
                if (_time.Equals(0f)) {
                    _isRunning = false;
                    onFinished?.Invoke();
                }
            }
        }

        private IEnumerator DoScale(Transform transform, Vector3 scale, float duration) {
            _tween = transform.DOScale(scale, duration).SetEase(easeType);
            yield return new WaitForSeconds(duration);
            onFinished?.Invoke();
        }
    }
}
