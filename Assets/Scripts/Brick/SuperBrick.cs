using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBrick : Brick
{
    private void Damage(int _damage)
    {
        currentHealth -= _damage;

        StartCoroutine(ResetHealthAfterDelay(2.0f));
        if (currentHealth <= 0)
        {     
            Death();
        }
    }

    private IEnumerator ResetHealthAfterDelay(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        currentHealth = 2;
    }
}
