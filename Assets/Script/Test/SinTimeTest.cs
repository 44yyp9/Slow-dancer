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
        float frequency = 1.0f;        // �T�C���g�̎��g��
        float amplitude = 1.0f;        // �T�C���g�̐U��
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
            // �T�C���g�ő��x�ω������
            float velocity = Mathf.Sin(time * frequency) * amplitude;
            Debug.Log(velocity);
            */
        }
    }
}
