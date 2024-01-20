using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    public Rigidbody2D rigibody;
    [SerializeField] private CircleCollider2D circleCollider;
    public int attackDamage;

    public void LaunchBall()
    {
        circleCollider.enabled = true;
        rigibody.bodyType = RigidbodyType2D.Dynamic;
        rigibody.AddForce(new Vector2(30f, speed));
    }
}
