using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Test
{
    public class Live2dHittingTest : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D coins)
        {
            if (coins.TryGetComponent(out Coin coin))
            {
                Debug.Log("test");
            }
        }
    }
}
