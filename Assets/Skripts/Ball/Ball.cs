using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _shootForce;
    [SerializeField] private Vector3 _offset;

    private Rigidbody _rigidbody;
    private Transform _target;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        Vector3 shootDirection = _target.position - transform.position;
        shootDirection += _offset;
        _rigidbody.AddForce(shootDirection * _shootForce, ForceMode.Impulse);
    }

    public void SetTargetPosition(Transform target)
    {
        _target = target;
    }

    public void IncreaseSize()
    {
        transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime,
                                           transform.localScale.y + Time.deltaTime,
                                           transform.localScale.z + Time.deltaTime);
    }
}
