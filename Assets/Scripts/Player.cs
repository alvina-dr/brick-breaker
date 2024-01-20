using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Ball currentBall;
    public int playerIndex { get; private set; }
    [SerializeField] Rigidbody2D rigibody;
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private Transform ballHolder;
    [SerializeField] private float speed;
    [SerializeField] private float maxBouncedAngle;
    public List<PlayerInput> playerInputList = new List<PlayerInput>();
    float direction;

    private void Start()
    {
        currentBall = Instantiate(ballPrefab);
        currentBall.transform.position = ballHolder.position;
        currentBall.transform.parent = ballHolder;
    }

    private void Update()
    {
        direction = 0;
        if (Input.GetKey(playerInputList[playerIndex].left))
        {
            direction = -speed;
        }
        if (Input.GetKey(playerInputList[playerIndex].right))
        {
            direction = speed;
        }
        if (Input.GetKeyDown(playerInputList[playerIndex].interract))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rigibody.AddForce(new Vector2(direction, 0));
    }

    private void Shoot()
    {
        if (currentBall == null) return;
        currentBall.transform.parent = null;
        currentBall.LaunchBall();
        currentBall = null;
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        Ball _ball = _collision.gameObject.GetComponent<Ball>();

        if (_ball != null)
        {
            Vector3 _paddlePosition = transform.position;
            Vector2 _contactPoint = _collision.GetContact(0).point;

            float _offset = _paddlePosition.x - _contactPoint.x;
            float _width = _collision.otherCollider.bounds.size.x / 2;

            float _currentAngle = Vector2.SignedAngle(Vector2.up, _ball.rigibody.velocity);
            float _bounceAngle = (_offset / _width) * maxBouncedAngle;
            float _newAngle = Mathf.Clamp(_currentAngle + _bounceAngle, -maxBouncedAngle, maxBouncedAngle);

            Quaternion _rotation = Quaternion.AngleAxis(_newAngle, Vector3.forward);
            _ball.rigibody.velocity = _rotation * Vector3.up * _ball.rigibody.velocity.magnitude;
        }
    }

    public void SetupPlayer(int _playerIndex)
    {
        playerIndex = _playerIndex;
        //setup input
    }

    [System.Serializable]
    public class PlayerInput {
        public KeyCode left;
        public KeyCode right;
        public KeyCode interract;
    }
}
