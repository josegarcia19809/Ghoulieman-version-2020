using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private float timeSinceLastHit = 2.0f;
    [SerializeField] private float timer = 0.0f;
    [SerializeField] private Slider healthSlider;

    private Animator _animator;
    private CharacterMovement _characterMovement;

    private AudioSource _audioSource;
    public AudioClip hurtAudio;
    public AudioClip deadAudio;

    void Start()
    {
        _animator = GetComponent<Animator>();
        currentHealth = startingHealth;
        _characterMovement = GetComponent<CharacterMovement>();
        _audioSource = GetComponent<AudioSource>();
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
        // Solamente hieren al Player
        if (currentHealth > 0)
        {
            GameManager.instance.PlayerHit(currentHealth);
            _animator.Play("Player_Hurt");
            currentHealth -= 10;
            healthSlider.value = currentHealth;
            _audioSource.PlayOneShot(hurtAudio);
        }
        else // Aqui matan al Player
        {
            GameManager.instance.PlayerHit(currentHealth);
            _animator.SetTrigger("isDead");
            _characterMovement.enabled = false;
            _audioSource.PlayOneShot(deadAudio);
        }
    }
}