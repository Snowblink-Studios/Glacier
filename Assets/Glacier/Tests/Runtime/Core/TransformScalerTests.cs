using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Glacier.Core.Transforms;

namespace Glacier.Core.Tests {
    public class TransformScalerTests {

        [UnityTest]
        public IEnumerator Scaling() {
            var g = new GameObject("Scaler");
            var scaler = g.AddComponent<TransformScaler>();
            scaler.SetDuration(2f);

            var hasReturned = false;
            var returnedScale = Vector3.zero;
            scaler.OnFinished.AddListener(() => {
                hasReturned = true;
                returnedScale = scaler.transform.localScale;
            });
            scaler.Scale(0.0f, 1.2f);

            var timeout = 10f;
            while (!hasReturned && timeout > 0f) {
                timeout -= Time.deltaTime;
                yield return null;
            }

            Assert.AreEqual(true, hasReturned);
            Assert.AreEqual(1.2f, scaler.transform.localScale.x);
            Assert.AreEqual(1.2f, scaler.transform.localScale.y);
            Assert.AreEqual(1.2f, scaler.transform.localScale.z);
        }
    }
}
