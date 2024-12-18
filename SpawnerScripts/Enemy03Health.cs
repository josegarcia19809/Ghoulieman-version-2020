using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 10;
    [SerializeField] private int currentHealth;

    private new Rigidbody rigidbody;
    private SphereCollider sphereCollider;
    private new AudioSource audio;
    public AudioClip killAudio;
    public GameObject explosionEffect;

    public AudioClip clip;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        currentHealth = startingHealth;
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.instance.GameOver)
        {
            if (other.CompareTag("PlayerWeapon"))
            {
                TakeHit();
            }
        }
    }

    void TakeHit()
    {
        if (currentHealth > 0)
        {
            GameObject newExplosionEffect = (GameObject)
                Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(newExplosionEffect, 1);
            currentHealth -= 10;
        }

        if (currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        sphereCollider.enabled = false;
        audio.PlayOneShot(killAudio);
        Destroy(gameObject);
    }
}