using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerShooter))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Target _target;
    [SerializeField] private float _minDistanceToMove;

    private PlayerShooter _playerShooter;
    private int _obstacleLayerIndex;
    private int _layerMask;

    public Vector3 Direction { get; private set; }


    private void Start()
    {
        SetStartValues();
        InitializeLayerMask();
        SetComponents();
    }

    private void SetComponents()
    {
        _playerShooter = GetComponent<PlayerShooter>();
    }

    private void InitializeLayerMask()
    {
        _obstacleLayerIndex = LayerMask.NameToLayer("Obstacle");
        _layerMask = (1 << _obstacleLayerIndex);
    }

    private void SetStartValues()
    {
        Direction = _target.transform.position - transform.position;
        Direction = new Vector3(Direction.x, transform.position.y, Direction.z);
        transform.rotation = Quaternion.LookRotation(Direction);
    }

    private void FixedUpdate()
    {
        TryMove();
    }

    private void TryMove()
    {
        if (!_playerShooter.IsBallIncreasing)
        {
            if (!Physics.SphereCast(transform.position, transform.localScale.x, Direction, out RaycastHit hit, _minDistanceToMove, _layerMask))
            {
                transform.position = Vector3.MoveTowards(transform.position, Direction, _speed * Time.fixedDeltaTime);
            }
        }
    }
}
