using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Animator))]
public class DoorOpenZone : MonoBehaviour
{
    private const string OPEN_DOOR = "OpenDoor";
    private const string CLOSE_DOOR = "CloseDoor";

    [SerializeField] private float _openDoorRange;

    private SphereCollider _collider;
    private Animator _animator;


    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _animator = GetComponent<Animator>();
        _collider.radius = _openDoorRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        _animator.SetTrigger(OPEN_DOOR);
    }

    public void CloseDoor()
    {
        _animator.SetTrigger(CLOSE_DOOR);
    }
}
