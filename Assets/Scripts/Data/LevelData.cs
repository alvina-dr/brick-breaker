using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public List<WaveEntry> waveList = new List<WaveEntry>();
    
    [System.Serializable]
    public class WaveEntry
    {
        public Wave wave;
        public float spaceBeforeWave;
    }
}
