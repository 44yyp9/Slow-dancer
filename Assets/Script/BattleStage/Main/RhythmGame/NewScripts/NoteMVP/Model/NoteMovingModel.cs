using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace RhythmGameScene
{
    public class NoteMovingModel
    {
        private const float Speed = 10f;
        public float MoveSpeed()
        {
            var speed = Speed * GameTime.playingTime;
            return speed;
        }
        public void Move(GameObject note,GameObject taget)
        {
            var speed = MoveSpeed();
            var notePosiX = note.transform.position.x;
            var tagetPosiX= taget.transform.position.x;
            var posiVoluem= notePosiX - tagetPosiX; //taget�̕����傫���ꍇ�E�ɐi�߂�
            if (posiVoluem >= 0) speed *= -1;
            //�ړ��̎���
            note.transform.position += new Vector3(speed, 0, 0);
        }
    }
}
