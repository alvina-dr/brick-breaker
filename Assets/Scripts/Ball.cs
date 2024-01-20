using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    public Rigidbody2D rigibody;
    public int attackDamage;

    public void LaunchBall()
    {
        rigibody.AddForce(new Vector2(30f, speed));
    }
}
