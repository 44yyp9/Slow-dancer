using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

namespace AddStoryScript
{
    public class StoryChaneged : MonoBehaviour
    {
        /// <summary>
        /// 全体的な設計を考えない実装で行くためこれで実装する
        /// </summary>
        private bool TextWindowActived = false;
        [SerializeField] private GameObject TextWindow;
        [SerializeField] private string NextSceneName;
        private void Update()
        {
            if (TextWindow.activeSelf)
            {
                TextWindowActived = true;
            }
            if (!TextWindow.activeSelf&&TextWindowActived)
            {
                SceneManager.LoadScene(NextSceneName);
            }
        }
    }
}
