using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Test
{
    public class InputController : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                Debug.Log("a");
            }
        }
    }
}
