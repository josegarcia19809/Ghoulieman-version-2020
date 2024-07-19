using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItem : MonoBehaviour
{
    private GameObject player;
    private AudioSource audio;
    private ParticleSystem _particleSystemPlayer;
    private PlayerHealth _playerHealth;

    private MeshRenderer _meshRenderer;
    private ParticleSystem _particleSystemBrain;

    [Obsolete("Obsolete")]
    void Start()
    {
        player = GameManager.instance.Player;
        _playerHealth = player.GetComponent<PlayerHealth>();
        _playerHealth.enabled = true;

        _particleSystemPlayer = player.GetComponent<ParticleSystem>();
        _particleSystemPlayer.enableEmission = false;

        _meshRenderer = GetComponentInChildren<MeshRenderer>();
        _particleSystemBrain = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            StartCoroutine(InvincibleRoutine());
            _meshRenderer.enabled = false;

        }
    }

    public IEnumerator InvincibleRoutine()
    {
        _particleSystemPlayer.enableEmission = true;
        _playerHealth.enabled = false;
        _particleSystemBrain.enableEmission = false;
        yield return new WaitForSeconds(10f);

        _particleSystemPlayer.enableEmission = false;
        _playerHealth.enabled = true;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}