using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int PointsForDestroying = 10;
    private void Damage(int _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        GPCtrl.Instance.AddScore(PointsForDestroying);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        Ball _ball = _collision.gameObject.GetComponent<Ball>();

        if (_ball != null)
        {
            Damage(_ball.attackDamage);
        }
    }

}
