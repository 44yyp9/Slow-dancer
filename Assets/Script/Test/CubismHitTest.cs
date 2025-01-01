using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Live2D.Cubism.Framework.Raycasting;

namespace Test
{
    public class CubismHitTest : MonoBehaviour
    {
        private void Update()
        {
            // マウスクリックの処理を行う（必要であれば別の条件に変更）
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            // CubismRaycasterを使ってLive2Dモデルに向けてRayを飛ばす
            var raycaster = GetComponent<CubismRaycaster>();
            var results = new CubismRaycastHit[4]; // 最大4つの衝突結果を取得
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hitCount = raycaster.Raycast(ray, results);

            // Live2Dモデルとの衝突判定結果を処理
            string resultsText = "Live2D Results: " + hitCount.ToString();
            for (var i = 0; i < hitCount; i++)
            {
                resultsText += "\nDrawable: " + results[i].Drawable.name;
            }

            // 他のゲームオブジェクトとの衝突判定（Physics.Raycastを使用）
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // 他のゲームオブジェクトに当たった場合
                resultsText += "\nHit Object: " + hit.collider.name;
            }

            // 衝突判定結果を表示
            Debug.Log(resultsText);
        }
    }
}
