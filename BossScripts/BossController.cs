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


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossAwake)
        {
            print("bossAwake");
            animator.SetBool("bossAwake", true);
            if (inBattle)
            {
                if (!attacking)
                {
                    idleTimer += Time.deltaTime;
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