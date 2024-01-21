using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleBrick : Brick
{

    public override void Damage(int _damage)
    {
        Brick[] otherBricks = FindObjectsOfType<ProtectorBrick>();

        if (otherBricks.Length <= 0)
        {
            currentHealth -= _damage;
            if (currentHealth <= 0)
            {
                Death();
            }
        }       
    }
}
