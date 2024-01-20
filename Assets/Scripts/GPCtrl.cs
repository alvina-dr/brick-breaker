using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPCtrl : MonoBehaviour
{
    public static GPCtrl Instance;
    Player player;
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
    }

    public void SpecialEffect()
    {
        
    }
}
