using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy01Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 20;
    [SerializeField] private float timeSinceLastHit = 0.5f;
    [SerializeField] private float dissaperSpeed = 2f;
    [SerializeField] private int currentHealth;

    private float timer = 0f;
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private bool isAlive;
    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;
    private bool dissapearEnemy = false;

    public bool IsAlive
    {
        get { return isAlive; }
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        isAlive = true;
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
}