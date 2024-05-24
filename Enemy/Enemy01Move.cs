using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy01Move : MonoBehaviour
{
    [SerializeField] private Transform player;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private Enemy01Health _enemy01Health;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemy01Health = GetComponent<Enemy01Health>();
    }

    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 12)
        {
            if (!GameManager.instance.GameOver && _enemy01Health.IsAlive)
            {
                // Si detecta que el Player está en rango entonces se moverá a esa posición
                _navMeshAgent.SetDestination(player.position);
                _animator.SetBool("isWalking", true);
                _animator.SetBool("isIdle", false);
            }
            
        }

        else if (GameManager.instance.GameOver || !_enemy01Health.IsAlive)
        {
            print("Game over");
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isIdle", true);
            _navMeshAgent.enabled = false;
        }
    }
}