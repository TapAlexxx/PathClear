using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))] 
public class BallCollisionHandler : MonoBehaviour
{
    private List<Obstacle> _obstaclesInExplodeRange = new List<Obstacle>();


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Explode();
            Destroy(gameObject);
        }
        else if (collision.gameObject.TryGetComponent(out Target target))
        {
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        foreach (Obstacle obstacle in _obstaclesInExplodeRange)
        {
            obstacle.Infect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            _obstaclesInExplodeRange.Add(obstacle);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            _obstaclesInExplodeRange.Remove(obstacle);
        }
    }
}
