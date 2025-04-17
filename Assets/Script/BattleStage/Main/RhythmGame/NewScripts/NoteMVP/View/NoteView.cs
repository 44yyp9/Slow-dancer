using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace RhythmGameScene
{
    public class NoteView : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void BadHide()
        {
            gameObject.SetActive(false); 
        }
        public void GoodHide()
        {
            gameObject.SetActive(false);
        }
    }
}
