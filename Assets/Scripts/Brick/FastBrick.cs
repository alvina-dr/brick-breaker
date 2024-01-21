using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBrick : Brick
{
    [SerializeField] private float DownSpeed = 0.2f;

    private void Update()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        // la brique descend vers le bas
        transform.Translate(Vector2.down * DownSpeed * Time.deltaTime);
    }
}
