using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Test
{
    public class CaltrigerTime : MonoBehaviour
    {
        private float conflictTime;
        private void Update()
        {
            if (GameTime.playingTime != 0)
            {
                conflictTime += GameTime.playingTime;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(conflictTime);
            conflictTime = 0;
        }
    }
}
