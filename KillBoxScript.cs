using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoxScript : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;
    void Start()
    {
        player = GameManager.instance.Player;
        playerHealth=player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerHealth.KillBox();
        }
    }
}
