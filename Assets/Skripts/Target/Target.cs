using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public event UnityAction Reached;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle) || other.TryGetComponent(out Ball ball))
        {
            Destroy(other.gameObject);
        }
        else if (other.TryGetComponent(out Player player))
        {
            Reached?.Invoke();
        }
    }
}
