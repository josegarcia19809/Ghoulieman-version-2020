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
    public AudioClip pickItem;

    private ParticleSystem _particleSystem;

    public LevelManager levelManager;

    public int CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value < 0 ? 0 : value;
    }
    
    public Slider HealthSlider => healthSlider;

    public float Timer
    {
        get => timer;
        set => timer = 0;
    }


    [Obsolete("Obsolete")]
    void Start()
    {
        _animator = GetComponent<Animator>();
        currentHealth = startingHealth;
        _characterMovement = GetComponent<CharacterMovement>();
        _audioSource = GetComponent<AudioSource>();

        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.enableEmission = false;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        PlayerKill();
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

    public void PowerUpHealth()
    {
        if (currentHealth <= 80)
        {
            currentHealth += 20;
        }
        else if (currentHealth < startingHealth)
        {
            CurrentHealth = startingHealth;
        }

        healthSlider.value = currentHealth;
        _audioSource.PlayOneShot(pickItem);
    }

    public void KillBox()
    {
        CurrentHealth = 0;
        healthSlider.value = currentHealth;
    }

    public void PlayerKill()
    {
        if (currentHealth <= 0)
        {
            levelManager.RespawnPlayer();
        }
    }
}