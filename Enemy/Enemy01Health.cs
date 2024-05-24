using System;
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
    private BoxCollider weaponCollider;
    private CapsuleCollider enemyCollider;

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
        weaponCollider = GetComponentInChildren<BoxCollider>();
        enemyCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (dissapearEnemy)
        {
            transform.Translate(-Vector3.up * dissaperSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if (other.tag == "PlayerWeapon")
            {
                TakeHit();
                timer = 0f;
            }
        }
    }

    private void TakeHit()
    {
        if (currentHealth > 0f)
        {
            _animator.Play("EnemyHurt");
            currentHealth -= 10;
        }

        if (currentHealth <= 0)
        {
            isAlive = false;
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        _capsuleCollider.enabled = false;
        _navMeshAgent.enabled = false;
        _animator.SetTrigger("EnemyDie");
        _rigidbody.isKinematic = true;
        weaponCollider.enabled = false;
        enemyCollider.enabled = false;
        StartCoroutine(RemoveEnemy());
    }

    IEnumerator RemoveEnemy()
    {
        yield return new WaitForSeconds(2f);
        dissapearEnemy = true;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}