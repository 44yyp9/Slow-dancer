using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Test
{
    public class TransfromePlayer : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private void Update()
        {
            var posiX = player.transform.position.x;
            var posiY = gameObject.transform.position.y;
            var posiZ = gameObject.transform.position.z;
            gameObject.transform.position = new Vector3(posiX, posiY, posiZ);
        }
    }
}
