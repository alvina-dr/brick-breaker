using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    public Rigidbody2D rigibody;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private CircleCollider2D paradeCollider;
    public int attackDamage;

    public void LaunchBall(Vector2 _direction)
    {
        speed *= GPCtrl.Instance.GeneralData.ballSpeedUpgrade;
        circleCollider.enabled = true;
        rigibody.bodyType = RigidbodyType2D.Dynamic;
        rigibody.AddForce(_direction.normalized * speed);
        paradeCollider.enabled = true;
    }

    public void DeactivateMovement()
    {
        rigibody.velocity = Vector2.zero;
        rigibody.bodyType = RigidbodyType2D.Kinematic;
        circleCollider.enabled = false;
        paradeCollider.enabled = false;
    }

    private void Update()
    {
        rigibody.velocity = rigibody.velocity.normalized * speed; 
    }
}
