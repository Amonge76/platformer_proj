using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class EnemyController : MonoBehaviour
{

    private int _EnemyHp;
    private playerControler _target;
    private float _mySpeed;
    private float _lookSpeed = 3f;
    private float _searchTime = 1f;
    private float _NextScan = 0;
    private float _patrolRadius = 10f;
    private bool _IsWaiting;
    private Vector3 _currentDestination;
    private float _waypointTimer = 0f;
    private float _waypointWaitTime = 2f;
    [SerializeField] private float _searchRadius;
    [SerializeField] private LayerMask _searchlayer;
    private EnemyState _myState = EnemyState.Idle;

    [SerializeField] private NavMeshAgent _agent;

    public void Initiate(EnemySO stats)
    {
        _EnemyHp = stats.HP;
        _mySpeed = stats.Speed;

        _agent.speed = _mySpeed;
    }

    private void Update()
    {
        _NextScan += Time.deltaTime;
        if(_NextScan >= _searchTime)
        {
            SearchForPlayer();
            _NextScan = 0f;
        }

        switch(_myState)
        {
            case EnemyState.Idle:
            Patrol();
            break;
            case EnemyState.Chase:
            Chase();
            LookAtTarget();
            break;
            case EnemyState.Attack:
            //
            break;
        }
    }

    private void Patrol()
    {
        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            if (!_IsWaiting)
            {
                _IsWaiting = true;
                _waypointTimer += Time.time;
            }
            else if (Time.time >= _waypointWaitTime)
            {
                _IsWaiting = false;
                GoToRandomPoint();
            }
            
        }
    }

    private void GoToRandomPoint()
    {
        Vector3 randomDir = UnityEngine.Random.insideUnitSphere * _patrolRadius;
        randomDir += transform.position;

        NavMeshHit navHit;

        if (NavMesh.SamplePosition(randomDir, out navHit, _patrolRadius, NavMesh.AllAreas))
        {
            _currentDestination = navHit.position;
            _agent.SetDestination(_currentDestination);
        }
    }

    private void LookAtTarget()
    {
        Vector3 direction = (_target.transform.position - transform.position);
        direction.y = 0;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _lookSpeed * Time.deltaTime);
        }
    }

    private void SearchForPlayer()
    {
       Collider[] hits = Physics.OverlapSphere(transform.position, _searchRadius, _searchlayer); 

       if(hits.Length > 0)
        {
            _target = hits[0].GetComponent<playerControler>();

            _myState = EnemyState.Chase;
        }
        else
        {
            _target = null;
            _myState = EnemyState.Idle;
        }
    }

    private void Chase()
    {
        _agent.SetDestination(_target.transform.position);
    }

    public void TakeDmg(int dmg)
    {
        _EnemyHp -= dmg;
    }
}


public enum EnemyState
{
    Idle,
    Chase,
    Attack,
    Frozen,
}