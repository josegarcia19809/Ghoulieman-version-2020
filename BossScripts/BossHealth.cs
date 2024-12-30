using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int bossHealth = 20;
    private Animator animator;
    public bool bossDead = false;
    public BossController bossController;
    
    private CapsuleCollider capsuleCollider;
    private BoxCollider weaponCollider;
    private SphereCollider triggerCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Boss").GetComponent<Animator>();
        bossController = GameObject.Find("Boss").GetComponent<BossController>();
        capsuleCollider = GameObject.Find("Boss").GetComponent<CapsuleCollider>();
        weaponCollider = GameObject.Find("Boss").GetComponentInChildren<BoxCollider>();
        triggerCollider = GameObject.Find("Boss").GetComponentInChildren<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerWeapon") && bossHealth > 0)
        {
            animator.SetTrigger("isHit");
            bossHealth--;
            print("Boss Health: " + bossHealth);
        }
        else
        {
            BossDead();
        }
    }

    void BossDead()
    {
        bossDead = true;
        animator.SetTrigger("isDead");
        bossController.bossAwake = false;
        capsuleCollider.enabled = false;
        weaponCollider.enabled = false;
        triggerCollider.enabled = false;
    }
}