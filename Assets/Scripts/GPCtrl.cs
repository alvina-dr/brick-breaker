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
    public int levelID = -1;
    public List<GameObject> levelList = new List<GameObject>();
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
        DOVirtual.DelayedCall(2f, () => StartLevel());

    }

    private void Update()
    {
        if (FindObjectsOfType<Brick>().Length == 0)
        {
            //next level
            StartLevel();
        }
    }

    public void StartLevel()
    {
        levelID++;
        Instantiate(levelList[levelID]);
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
