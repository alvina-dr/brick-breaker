using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPCtrl : MonoBehaviour
{
    public static GPCtrl Instance;
    public Player playerPrefab;
    public List<Player> playerList = new List<Player>();

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
    }

    public void SpecialEffect()
    {
        
    }
}
