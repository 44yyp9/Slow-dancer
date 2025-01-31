using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Test
{
    public class SingletonDebuged : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log(Options.bgmValue);
        }
    }
}
