using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using static Assets.Scripts.Lib.Math.Function;

namespace Assets.Scripts.Lib.Unity {
    public class BackgroundSlice_Animation : MonoBehaviour {
        [SerializeField] private FunctionName function = FunctionName.smooth_FTF;
        [SerializeField] private int _from = 0;
        [SerializeField] private int _to = 200;
        [SerializeField] private int _step_Multiplier = 10;
        private float _currentStep = 0;
        private int _currentValue = 0;

        private UIDocument _doc;
        private VisualElement _root;
        private IEnumerable _parents;
        private VisualElement _parent0;
        // Start is called before the first frame update
        private void Start() {
            this._doc = this.GetComponent<UIDocument>();
            this._root = this._doc.rootVisualElement;
            this._parents = this._root.Children();
            foreach (var parent in this._parents) {
                this._parent0 = (VisualElement)parent;
                //Debug.Log("Will animate unitySlice{Left,Right,Top,Bottom} for: " + this._parent0.name);
                break;
            }
            this._currentStep = this._from;
        }

        // Update is called once per frame
        private void Update() {
            if (this._parent0 == null) return;
            if (this._currentStep >= this._to) this._currentStep = this._from;
            this._currentStep += Time.deltaTime * this._step_Multiplier;
            this._currentValue = (int)fx(this.function, this._currentStep, this._from, this._to);
            StyleInt currentValue = new(this._currentValue);
            this._parent0.style.unitySliceLeft = currentValue;
            this._parent0.style.unitySliceRight = currentValue;
            this._parent0.style.unitySliceTop = currentValue;
            this._parent0.style.unitySliceBottom = currentValue;
            //Debug.Log(currentValue);
        }
    }
}
