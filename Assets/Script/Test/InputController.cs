using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Test
{
    public class InputController : MonoBehaviour
    {
        int Test = 0;
        private void Start()
        {
            Test = 0;
        }
        private void Update()
        {
            var inputManeger = new InputPlayerManeger();
            if (inputManeger.inputHandler())
            {
                Test++;
                Debug.Log("test"+Test.ToString());
            }
        }
    }
}
