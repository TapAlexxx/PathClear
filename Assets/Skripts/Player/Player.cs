using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _startSize;
    [SerializeField] private float _minSize;

    private float _currentSize;
    private float _normalizedSize;

    public float NormalizedSize => _normalizedSize;
    public float MinSize => _minSize;

    public event UnityAction Dead;


    public void ResetPlayer()
    {
        SetStartSize();
        transform.position = _startPoint.position;
    }

    private void SetStartSize()
    {
        _currentSize = _startSize;
        transform.localScale = Vector3.one * _startSize;
        _normalizedSize = _currentSize / _startSize;
    }

    public void ReduceSize()
    {
        transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime,
                                           transform.localScale.y - Time.deltaTime,
                                           transform.localScale.z - Time.deltaTime);
        _currentSize = transform.localScale.x;

        if (IsMinimumSize())
        {
            Dead?.Invoke();
        }
    }

    private bool IsMinimumSize()
    {
        _normalizedSize = _currentSize / _startSize;
        return _normalizedSize < _minSize;
    }
}
