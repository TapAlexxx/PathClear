using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PathRenderer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset;

    private LineRenderer _lineRenderer;


    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void LateUpdate()
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _target.position + _offset);
        _lineRenderer.startWidth = _player.transform.localScale.x;
        _lineRenderer.endWidth = _player.transform.localScale.x;
    }
}
