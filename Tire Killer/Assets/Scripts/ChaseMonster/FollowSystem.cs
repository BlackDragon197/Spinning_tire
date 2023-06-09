using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowSystem : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    private NavMeshAgent _agent;

    [SerializeField]
    private float _speedIncreaseValue = 2f;
    [SerializeField]
    private float _increaseInterval = 2f;

    private WaitForSeconds _chaseTimeInterval;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _chaseTimeInterval = new WaitForSeconds(_increaseInterval);
    }

    private void Start()
    {
        StartCoroutine(IncreaseSpeed(_chaseTimeInterval));
    }
    private void Update()
    {
       _agent.SetDestination(_playerTransform.position);
    }

    IEnumerator IncreaseSpeed(WaitForSeconds _timeInterval)
    {
        yield return _timeInterval;
        _agent.speed += _speedIncreaseValue;
        StartCoroutine(IncreaseSpeed(_chaseTimeInterval));
    }


}
