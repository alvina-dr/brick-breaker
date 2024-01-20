using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Ball currentBall;
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private Transform ballHolder;
    [SerializeField] private float speed;

    private void Start()
    {
        currentBall = Instantiate(ballPrefab);
        currentBall.transform.position = ballHolder.position;
        currentBall.transform.parent = ballHolder;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (currentBall == null) return;
        currentBall.transform.parent = null;
        currentBall.LaunchBall();
        currentBall = null;
    }
}
