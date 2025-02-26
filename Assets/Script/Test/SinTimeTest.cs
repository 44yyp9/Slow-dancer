using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.Mathematics;

namespace Test
{
    public class SinTimeTest : MonoBehaviour
    {
        float time = 0;
        float frequency = 1.0f;        // ƒTƒCƒ“”g‚Ìü”g”
        float amplitude = 1.0f;        // ƒTƒCƒ“”g‚ÌU•
        private void Start()
        {
            time = Mathf.PI;
            float test=Mathf.Sin(time);
            Debug.Log(test);
        }
        private void Update()
        {
            /*
            time += GameTime.playingTime;
            // ƒTƒCƒ“”g‚Å‘¬“x•Ï‰»‚ğì‚é
            float velocity = Mathf.Sin(time * frequency) * amplitude;
            Debug.Log(velocity);
            */
        }
    }
}
