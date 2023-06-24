#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Game {
    public class BasicHealth : Health {

        protected override void Start() {
            base.Start();
            //Debug.Log("BasicHealth Start() called.");
        }
    }
}
#endif
