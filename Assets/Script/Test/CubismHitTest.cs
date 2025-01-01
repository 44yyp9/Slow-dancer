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
            // �}�E�X�N���b�N�̏������s���i�K�v�ł���Εʂ̏����ɕύX�j
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            // CubismRaycaster���g����Live2D���f���Ɍ�����Ray���΂�
            var raycaster = GetComponent<CubismRaycaster>();
            var results = new CubismRaycastHit[4]; // �ő�4�̏Փˌ��ʂ��擾
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hitCount = raycaster.Raycast(ray, results);

            // Live2D���f���Ƃ̏Փ˔��茋�ʂ�����
            string resultsText = "Live2D Results: " + hitCount.ToString();
            for (var i = 0; i < hitCount; i++)
            {
                resultsText += "\nDrawable: " + results[i].Drawable.name;
            }

            // ���̃Q�[���I�u�W�F�N�g�Ƃ̏Փ˔���iPhysics.Raycast���g�p�j
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // ���̃Q�[���I�u�W�F�N�g�ɓ��������ꍇ
                resultsText += "\nHit Object: " + hit.collider.name;
            }

            // �Փ˔��茋�ʂ�\��
            Debug.Log(resultsText);
        }
    }
}
