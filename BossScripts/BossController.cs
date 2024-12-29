using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public bool bossAwake = false;
    private Animator animator;

    public bool inBattle = false;
    public bool attacking = false;
    public float idleTimer = 0.0f;
    public float idleWaitTime = 10.0f;

    private BossHealth bossHealth;
    public float attackTimer = 0.0f;
    public float attackWaitTime = 2.0f;

    private BoxCollider swordTrigger;
    public GameObject bossHealthBar;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bossHealth = GetComponent<BossHealth>();
        swordTrigger = GameObject.Find("Boss").GetComponentInChildren<BoxCollider>();
        bossHealthBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bossAwake)
        {
            print("bossAwake");
            animator.SetBool("bossAwake", true);
            bossHealthBar.SetActive(true);
            if (inBattle)
            {
                if (!attacking)
                {
                    idleTimer += Time.deltaTime;
                }
                else
                {
                    idleTimer = 0.0f;
                    attackTimer += Time.deltaTime;
                    if (attackTimer >= attackWaitTime)
                    {
                        attacking = false;
                        animator.SetTrigger("bossAttack");
                        attackTimer = 0.0f;
                        print("Boss Smash");
                        swordTrigger.enabled = true;
                        print("Sword Trigger is enable");
                    }
                }

                if (idleTimer >= idleWaitTime)
                {
                    print("Boss is attacking");
                    attacking = true;
                    idleTimer = 0.0f;
                }
            }
            else
            {
                idleTimer = 0.0f;
            }
        }
    }
}