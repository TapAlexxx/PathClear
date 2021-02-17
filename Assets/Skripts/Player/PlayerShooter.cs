using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Ball _template;
    [SerializeField] private float _shootPointOffset;
    [SerializeField] private float _increasingSpeed;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _shootPoint;

    private Player _player;
    private Ball _ball;
    private Coroutine _ballIncreasingCoroutine;

    public bool IsBallIncreasing { get; private set; }


    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.Dead += OnPlayerDead;
    }

    private void OnDisable()
    {
        _player.Dead -= OnPlayerDead;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ball = CreateNewBall();
            TryStartResizeBall(_ball);
        }
        if (Input.GetMouseButtonUp(0))
        {
            TryStopResizeBall(_ball);
            _ball.SetTargetPosition(_target);
            if (_ball != null)
            {
                _ball.Shoot();
            }
        }
    }

    private Ball CreateNewBall()
    {
        return Instantiate(_template, _shootPoint.position, Quaternion.identity);
    }

    private void TryStartResizeBall(Ball ball)
    {
        if (ball != null)
        {
            IsBallIncreasing = true;
            _ballIncreasingCoroutine = StartCoroutine(ResizeBall(ball));
        }
    }

    private void TryStopResizeBall(Ball ball)
    {
        if (ball != null)
        {
            IsBallIncreasing = false;
            StopCoroutine(_ballIncreasingCoroutine);
        }
    }

    private void OnPlayerDead()
    {
        TryStopResizeBall(_ball);
        Destroy(_ball.gameObject);
    }

    private IEnumerator ResizeBall(Ball ball)
    {
        while (IsBallIncreasing)
        {
            _player.ReduceSize();
            ball.IncreaseSize();
            yield return new WaitForFixedUpdate();
        }
    }
}
