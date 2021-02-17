using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Target _target;
    [SerializeField] private DoorOpenZone _doorOpenZone;
    [SerializeField] private ObstacleGenerator _obstacleGenerator;


    private void OnEnable()
    {
        _player.Dead += OnPlayerDead;
        _target.Reached += OnTargetReached;
    }

    private void OnDisable()
    {
        _player.Dead -= OnPlayerDead;
        _target.Reached -= OnTargetReached;
    }

    private void Start()
    {
        _obstacleGenerator.ResetLevel();
        _player.ResetPlayer();
    }

    private void RestartLevel()
    {
        _obstacleGenerator.ResetLevel();
        _player.ResetPlayer();
        _doorOpenZone.CloseDoor();
    }

    private void OnTargetReached()
    {
        RestartLevel();
    }

    private void OnPlayerDead()
    {
        RestartLevel();
    }
}
