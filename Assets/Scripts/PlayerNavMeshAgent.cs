using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshAgent : MonoBehaviour
{
    public Transform target;
    public Transform[] targets;
    public float accurateDistance = 0.1f;

    private NavMeshAgent _agent;
    private int _currentTarget;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // _agent.destination = target.position;\
        SetWayPoint();
    }

    public void SetWayPoint()
    {
        if (targets.Length == 0)
        {
            Debug.Log("No Way Points to Go to");
            return;
        }
        if (Vector3.Distance(targets[_currentTarget].position, transform.position) < accurateDistance)
        {
            this.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            _currentTarget++;
            if (_currentTarget >= targets.Length)
            {
                _currentTarget = 0;
            }
        }

        _agent.SetDestination(targets[_currentTarget].position);
    }
}
