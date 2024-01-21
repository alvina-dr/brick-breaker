using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    public Ball currentBall;
    public int playerIndex { get; private set; }
    [SerializeField] Rigidbody2D rigibody;
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private Transform ballHolder;
    [SerializeField] private float speed;
    [SerializeField] private float maxBouncedAngle;
    public List<PlayerInput> playerInputList = new List<PlayerInput>();
    float direction;
    public Transform shootingDirection;
    public Transform pivot;
    public float timer;

    private void Start()
    {
        GetBall();
    }

    private void Update()
    {
        direction = 0;
        timer += Time.deltaTime;
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
            timer = 0;
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
        currentBall.LaunchBall(shootingDirection.position - pivot.position);
        currentBall = null;
        pivot.transform.DOKill();
        pivot.DOScale(1.1f, .1f).OnComplete(() =>
        {
            pivot.DOScale(0, .1f);
        });
    }

    public void GetBall()
    {
        Debug.Log("GET BALL");
        currentBall = Instantiate(ballPrefab);
        currentBall.transform.position = ballHolder.position;
        currentBall.transform.parent = ballHolder;
        pivot.DOScale(1.1f, .1f).OnComplete(() =>
        {
            pivot.DOScale(1, .1f);
        });
        pivot.transform.localRotation = Quaternion.identity;
        pivot.transform.Rotate(Vector3.forward, 60);
        pivot.transform.DORotate(new Vector3(0, 0, -60), .5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    public void GrabBall(Ball _ball)
    {
        Debug.Log("GRAB BALL");
        currentBall = _ball;
        currentBall.DeactivateMovement();
        currentBall.transform.parent = ballHolder;
        currentBall.transform.DOMove(ballHolder.transform.position, .1f);
        pivot.DOScale(1.1f, .1f).OnComplete(() =>
        {
            pivot.DOScale(1, .1f);
        });
        pivot.transform.localRotation = Quaternion.identity;
        pivot.transform.Rotate(Vector3.forward, 60);
        pivot.transform.DORotate(new Vector3(0, 0, -60), .5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
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

            if (timer < GPCtrl.Instance.GeneralData.paradeDelay)
            {
                GrabBall(_ball);
            }
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
