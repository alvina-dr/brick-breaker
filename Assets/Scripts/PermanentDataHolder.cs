using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PermanentDataHolder : MonoBehaviour
{
    public static PermanentDataHolder Instance;
    public int playerNumber;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void LaunchGame(int _playerNum)
    {
        playerNumber = _playerNum;
        SceneManager.LoadScene("Game");
    }

    public void LaunchMainMenu()
    {

    }
}
