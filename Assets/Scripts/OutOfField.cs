using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfField : MonoBehaviour
{
    enum DetectionType {
        Ball = 0,
        Brick = 1
    }

    [SerializeField] private DetectionType detectionType;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        switch (detectionType)
        {
            case DetectionType.Ball:
                Ball _ball = _collision.GetComponent<Ball>();
                if (_ball != null)
                {
                    if (FindObjectsOfType<Ball>().Length == 1)
                    {
                        for (int i = 0; i < GPCtrl.Instance.playerList.Count; i++)
                        {
                            GPCtrl.Instance.playerList[i].GetBall();
                        }
                    }
                    Destroy(_ball.gameObject);
                }
                break;
            case DetectionType.Brick:
                Debug.Log("COLLISION " + _collision.name);
                Brick _brick = _collision.GetComponent<Brick>();
                if (_brick != null)
                {
                    Debug.Log("BRICK COLLISION");
                    GPCtrl.Instance.GameOver();
                }
                break;
        }
    }
}
