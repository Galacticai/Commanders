using Commanders.Assets.Scripts.Lib.Math.Numerics;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Commanders.Assets.Scripts.Lib.Unity {
    public class BackgroundSlice_Animation : MonoBehaviour {
        [SerializeField] private Function.FunctionName function = Function.FunctionName.Smooth_FTF;
        [SerializeField] private int _from;
        [SerializeField] private int _to = 200;
        [SerializeField] private int _step_Multiplier = 10;
        private float _currentStep;
        private int _currentValue;

        private VisualElement _parent0;
        // Start is called before the first frame update
        private void Start() {
            UIDocument _doc = GetComponent<UIDocument>();
            VisualElement _root = _doc.rootVisualElement;
            IEnumerable _parents = _root.Children();
            foreach (var parent in _parents) {
                _parent0 = (VisualElement)parent;
                //Debug.Log("Will animate unitySlice{Left,Right,Top,Bottom} for: " + this._parent0.name);
                break;
            }
            _currentStep = _from;
        }

        // Update is called once per frame
        private void Update() {
            if (_parent0 == null) return;
            if (_currentStep >= _to) _currentStep = _from;
            _currentStep += Time.deltaTime * _step_Multiplier;
            _currentValue = (int)Function.Fx(function, _currentStep, _from, _to);
            StyleInt currentValue = new(_currentValue);
            _parent0.style.unitySliceLeft = currentValue;
            _parent0.style.unitySliceRight = currentValue;
            _parent0.style.unitySliceTop = currentValue;
            _parent0.style.unitySliceBottom = currentValue;
            //Debug.Log(currentValue);
        }
    }
}
