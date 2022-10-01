using Assets.Scripts.Lib.Math.Numerics;
using UnityEngine;

namespace Assets.Animations {

    public class Fade : MonoBehaviour {
        [SerializeField] private Function.FunctionName function;
        private float _currentAnimationStep;
        [SerializeField] private float _fadeIn_Multiplier = 3, _fadeOut_Multiplier = 4;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private bool _fadeIn = false, _fadeOut = false;

        private bool _shown = false;
        public void showOnce() {
            if (_shown) return;
            _shown = true;
            show();
        }
        public void resetShown()
            => _shown = false;

        public void show() {
            _canvasGroup.interactable = true;
            _fadeIn = true;
        }
        public void hide() {
            _canvasGroup.interactable = false;
            _fadeOut = true;
        }

        private void Start() {
            _currentAnimationStep = _canvasGroup.alpha;
        }
        private void Update() {
            if (_fadeIn && _currentAnimationStep < 1) {
                _currentAnimationStep += Time.deltaTime * _fadeIn_Multiplier;
                _canvasGroup.alpha = (float)Function.Fx(function, _currentAnimationStep, 0, 1);
                if (_currentAnimationStep >= 1)
                    _fadeIn = false;
            }
            if (_fadeOut && _currentAnimationStep >= 0) {
                _currentAnimationStep -= Time.deltaTime * _fadeIn_Multiplier;
                _canvasGroup.alpha = (float)Function.Fx(function, _currentAnimationStep, 0, 1);
                if (_currentAnimationStep <= 0)
                    _fadeOut = false;
            }
        }
    }
}

