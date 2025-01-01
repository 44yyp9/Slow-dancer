using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Test
{
    public class Live2dCollider : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("hand");
        }
        public Transform handBone; // è‚Ìƒ{[ƒ“‚ğw’è
        private Collider handCollider;

        void Start()
        {
            handCollider = GetComponent<Collider>();
        }

        void Update()
        {
            if (handBone != null && handCollider != null)
            {
                handCollider.transform.position = handBone.position;
                handCollider.transform.rotation = handBone.rotation;
            }
        }
    }
}
