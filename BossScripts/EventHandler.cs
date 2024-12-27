using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    private CharacterMovement characterMovement;

    private Animator playerAnimator;
    private BossController bossController;

    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void EnableBossBattle()
    {
        characterMovement.enabled = true;
        playerAnimator.Play("Blend Tree");
        bossController.inBattle = true;
    }
}