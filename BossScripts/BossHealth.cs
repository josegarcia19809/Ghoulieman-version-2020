using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int bossHealth = 20;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Boss"). GetComponent<Animator>();
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
    }
}