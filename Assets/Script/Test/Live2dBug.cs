using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Test
{
    public class Live2dBug : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private float time = 0;
        private bool test;
        private void Start()
        {
            player.SetActive(false);
            time = 0;
            test = true;
        }
        private void Update()
        {
            time += Time.deltaTime;
            if (time>0.5f&&test)
            {
                player.SetActive(true);
                test = false;
            }
            
        }
    }
}
