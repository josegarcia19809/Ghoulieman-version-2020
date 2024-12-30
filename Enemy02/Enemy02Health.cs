using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy02Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 20;
    [SerializeField] private float timeSinceLastHit = 20;
    [SerializeField] private float dissapearSpeed = 20;
    [SerializeField] private int currentHealth = 20;

    private float timer = 0f;
    private Animator _animator;
    private bool isAlive;
    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;
    private bool dissapearEnemy = false;

    private AudioSource _audioSource;
    public AudioClip hurtAudio;
    public AudioClip killAudio;

    public bool IsAlive => isAlive;

    private DropItems _dropItems;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _animator = GetComponent<Animator>();
        isAlive = true;
        currentHealth = startingHealth;
        _audioSource = GetComponent<AudioSource>();
        _dropItems = GetComponent<DropItems>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (dissapearEnemy)
        {
            transform.Translate(-Vector3.up * (dissapearSpeed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if (other.CompareTag("PlayerWeapon"))
            {
                TakeHit();
                timer = 0f;
            }
        }
    }

    private void TakeHit()
    {
        if (currentHealth > 0)
        {
            _animator.Play("Enemy02Hurt");
            currentHealth -= 10;
            _audioSource.PlayOneShot(hurtAudio);
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
        _animator.SetTrigger("EnemyDie");
        _rigidbody.isKinematic = true;
        _audioSource.PlayOneShot(killAudio);
        StartCoroutine(RemoveEnemy());
        
        _dropItems.Drop();
    }

    IEnumerator RemoveEnemy()
    {
        yield return new WaitForSeconds(2f);
        dissapearEnemy = true;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}