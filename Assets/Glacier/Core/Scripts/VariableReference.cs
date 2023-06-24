#if GLACIER_UNITY
using System;
using UnityEngine;

namespace Glacier.Core {
    [Serializable]
    public class VariableReference {

        [SerializeField]
        private bool isConstant = false;
        [SerializeField]
        private Variable<int> variable;
        [SerializeField]
        private int constantValue;

        public int Variable {
            get => isConstant ? constantValue : variable.Value;
            set {
                if (isConstant) {
                    Debug.LogError("Can't modify constant variable.");
                }
                else {
                    if (variable != null) {
                        variable.Value = value;
                    }
                    else {
                        Debug.LogError("Referred variable is NULL.");
                    }
                }
            }
        }
    }
}
#endif
