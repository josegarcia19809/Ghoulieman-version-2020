using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItem : MonoBehaviour
{
    private GameObject player;
    private AudioSource audio;
    private ParticleSystem _particleSystem;
    private PlayerHealth _playerHealth;
    
    [Obsolete("Obsolete")]
    void Start()
    {
        player = GameManager.instance.Player;
        _playerHealth = player.GetComponent<PlayerHealth>();
        _playerHealth.enabled = true;

        _particleSystem = player.GetComponent<ParticleSystem>();
        _particleSystem.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
