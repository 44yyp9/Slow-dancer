using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameTime : MonoBehaviour
{
    private float time;
    [SerializeField] private bool isPlaying;
    public static float playingTime;
    [SerializeField] private bool isPause;
    public static float pauseTime;
    private void Start()
    {
        isPlaying = true;
        isPause=false;
    }
    private void Update()
    {
        time = Time.deltaTime;
        //�v���C���Ȃ�playingTime��0����Ȃ�
        if (isPlaying) playingTime = time;
        else playingTime = 0;
        //�|�[�Y���Ȃ�pauseTime��0����Ȃ�
        if(isPause) pauseTime = time;
        else pauseTime = 0;
    }
    //�ȉ��̃��\�b�h��񋟂��邱�Ƃ�play��pasuse�̐؂�ւ����s��
    public void playGame()
    {
        isPlaying=true;
        isPause=false;
    }
    public void pauseGame()
    {
        isPause=true;
        isPlaying=false;
    }
}
