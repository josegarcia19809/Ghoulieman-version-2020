using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth _playerHealth;

    void Start()
    {
        player = GameManager.instance.Player;
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            _playerHealth.PowerUpHealth();
            Destroy(gameObject);
        }
    }

    void Update()
    {
    }
}