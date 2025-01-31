using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class SaveDataStruct
{
    [System.Serializable]
    public struct SaveData
    {
        public bool Accessed;
        public int OpenedStages;
        public int PlayerMapPosition;
        public int Coins;
        [Serializable]
        public struct Costume
        {
            public bool Normal;
            public bool Cosutume1;
            public bool Cosutume2;
        }
        public List<Costume> Cosutumes;
        [Serializable]
        public struct StageScore
        {
            public bool IsCleared;
            public int HighScore;
            public int SecondScore;
            public int ThirdScore;
        }
        public List<StageScore> StagesScore;
    }
}
public class SoundVoulumeStruct
{
    [System.Serializable]
    public struct SoundVolumeData
    {
        public float BGMVolume;
        public float SEVolume;
    }
}
