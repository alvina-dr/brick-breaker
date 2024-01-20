using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UnityEvent OnStart;
    private bool started = false;
    
    public void Update()
    {
        if (Input.anyKeyDown && !started)
        {
            started = true;
            OnStart?.Invoke();
        }
    }
}
