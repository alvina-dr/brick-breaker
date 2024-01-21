using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public class GPCtrl : MonoBehaviour
{
    public static GPCtrl Instance;
    [BoxGroup("DATA")]
    public GeneralData GeneralData;
    public Player playerPrefab;
    public List<Player> playerList = new List<Player>();
    public int ScoreCount;
    public int levelID = 0;
    public float offset;
    public List<LevelData> levelList = new List<LevelData>();
    public List<Wave> waveList = new List<Wave>();
    [SerializeField] private Transform gridTransform;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Debug.Log("START GAME");
        for (int i = 0; i < PermanentDataHolder.Instance.playerNumber; i++)
        {
            Player _player = Instantiate(playerPrefab);
            _player.SetupPlayer(i);
            playerList.Add(_player);
        }
        StartLevel();
    }

    private void Update()
    {
        //if (FindObjectsOfType<Brick>().Length == 0)
        //{
        //    //next level
        //    StartLevel();
        //}
    }

    public void StartLevel()
    {
        float height = 0;
        for (int i = 0; i < levelList[levelID].waveList.Count; i++)
        {
            Wave _wave = Instantiate(levelList[levelID].waveList[i].wave, gridTransform);
            height += _wave.GetTilemapHeight() + levelList[levelID].waveList[i].spaceBeforeWave;
            _wave.transform.position = gridTransform.position + new Vector3(0, height + offset, 0);
            waveList.Add(_wave);
        }
    }

    public void AddScore(int points)
    {
        ScoreCount += points;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }

}
