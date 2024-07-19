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

    public GameObject pickupEffect;

    private ItemExplode _itemExplode;
    private SphereCollider _sphereCollider;

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

        _itemExplode = GetComponent<ItemExplode>();
        _sphereCollider = GetComponent<SphereCollider>();
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
        _itemExplode.Pickup();
        _sphereCollider.enabled = false;

        var emissionPlayer = _particleSystemPlayer.emission;
        emissionPlayer.enabled = true;
        _playerHealth.enabled = false;

        var emissionBrain = _particleSystemBrain.emission;
        emissionBrain.enabled = false;
        _playerHealth.Timer = 0;

        yield return new WaitForSeconds(10f);

        emissionPlayer = _particleSystemPlayer.emission;
        emissionPlayer.enabled = false;
        _playerHealth.enabled = true;

        Destroy(gameObject);
    }

    void Pickup()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
    }
}