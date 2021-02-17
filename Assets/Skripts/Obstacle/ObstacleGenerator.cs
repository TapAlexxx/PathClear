using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private Obstacle _obstacle;
    [SerializeField] private Target _target;
    [SerializeField] private Player _player;
    [SerializeField] private int _obstacleCount;
    [SerializeField] private Transform _minPosition;
    [SerializeField] private Transform _maxPosition;


    private void Start()
    {
        ResetLevel();
    }

    public void ResetLevel()
    {
        foreach (Transform obstacle in _container.transform)
        {
            Destroy(obstacle.gameObject);
        }

        Vector3 targetPath = _target.transform.position - _player.transform.position;
        for (int i = 0; i < _obstacleCount; i++)
        {
            Obstacle obstacle = Instantiate(_obstacle, _container.transform);
            obstacle.transform.position = GetNearbyPosition(targetPath);
        }
    }

    private Vector3 GetNearbyPosition(Vector3 path)
    {
        return new Vector3(Random.Range(_minPosition.position.x, _maxPosition.position.x),
                                       0,
                                       Random.Range(_minPosition.position.z, _maxPosition.position.z));
    }
}
