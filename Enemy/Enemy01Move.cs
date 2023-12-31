using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy01Move : MonoBehaviour
{
    [SerializeField] private Transform player;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 12)
        {
            print("Player in range");
            // Si detecta que el Player está en rango entonves se moverá a 
            // esa posición
            _navMeshAgent.SetDestination(player.position);
        }
    }
}