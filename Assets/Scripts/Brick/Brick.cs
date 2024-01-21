using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Build.Content;
using UnityEngine;
using DG.Tweening;

public class Brick : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] public int currentHealth;
    [SerializeField] public int PointsForDestroying = 50;
    public virtual void Damage(int _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        boxCollider.enabled = false;
        transform.DOScale(1.3f, .05f).OnComplete(() =>
        {
            transform.DOScale(0, .15f).OnComplete(() =>
            {
                GPCtrl.Instance.AddScore(PointsForDestroying);
                Destroy(gameObject);
            });
        });
    }
    
    public void OnCollisionEnter2D(Collision2D _collision)
    {
        Ball _ball = _collision.gameObject.GetComponent<Ball>();

        if (_ball != null)
        {
            Damage(_ball.attackDamage);
        }
    }

}
