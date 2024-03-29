using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private float timeSinceLastHit = 2.0f;
    [SerializeField] private float timer = 0.0f;

    private Animator _animator;
    private CharacterMovement _characterMovement;

    void Start()
    {
        _animator = GetComponent<Animator>();
        currentHealth = startingHealth;
        _characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if (other.CompareTag("Weapon"))
            {
                TakeHit();
                timer = 0;
            }
        }
    }

    void TakeHit()
    {
        if (currentHealth > 0)
        {
            GameManager.instance.PlayerHit(currentHealth);
            _animator.Play("Player_Hurt");
            currentHealth -= 10;
        }
        else
        {
            GameManager.instance.PlayerHit(currentHealth);
            _animator.SetTrigger("isDead");
            _characterMovement.enabled = false;
        }
    }
}