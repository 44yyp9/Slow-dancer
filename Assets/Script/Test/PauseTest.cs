using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Test
{
    public class PauseTest : MonoBehaviour
    {
        [SerializeField] private GameTime gameTime;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameTime.pauseGame();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                gameTime.playGame();
            }
        }
    }
}
