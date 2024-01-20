using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigibody;

    public void LaunchBall()
    {
        rigibody.AddForce(new Vector2(0, speed));
    }
}
