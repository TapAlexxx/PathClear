using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Obstacle : MonoBehaviour
{
    private const string INFECT = "Infect";

    [SerializeField] private float _ifectionTime;
    [SerializeField] private GameObject _infectionFX;

    private Animator _animator;
    

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Infect()
    {
        StartCoroutine(DestroyObstacle());
    }

    private IEnumerator DestroyObstacle()
    {
        _animator.SetTrigger(INFECT);
        while (_ifectionTime > 0)
        {
            _ifectionTime -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        GameObject infectFX = Instantiate(_infectionFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        Destroy(infectFX, 2);
        Destroy(gameObject);
    }
}
