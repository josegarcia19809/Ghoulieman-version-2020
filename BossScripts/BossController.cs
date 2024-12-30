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
    
    private SmoothFollow smoothFollow;
    private GameObject player;
    private PlayerHealth playerHealth;
    private BoxCollider bossCheckPoint;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bossHealth = GetComponentInChildren<BossHealth>();
        swordTrigger = GameObject.Find("Boss").GetComponentInChildren<BoxCollider>();
        bossHealthBar.SetActive(false);
        smoothFollow= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SmoothFollow>();
        player = GameManager.instance.Player;
        playerHealth = player.GetComponent<PlayerHealth>();
        bossCheckPoint = GameObject.Find("BossCheckPoint").GetComponent<BoxCollider>();
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
                       BossAttack03();
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
        BossReset();
    }

    void BossReset()
    {
        if (playerHealth.CurrentHealth == 0)
        {
            bossAwake = false;
            bossCheckPoint.isTrigger = true;
            print("Boss is sleeping again");
            smoothFollow.bossCameraActive = false;
            animator.Play("BossIdle");
            animator.SetBool("bossAwake", false);
            bossHealth.bossHealth = 20;
        }
    }

    void BossAttack01()
    {
        attacking = false;
        animator.SetTrigger("bossAttack");
        attackTimer = 0.0f;
        print("Boss attack 01");
        swordTrigger.enabled = true;
    }
    
    void BossAttack02()
    {
        attacking = false;
        animator.SetTrigger("bossAttack02");
        attackTimer = 0.0f;
        print("Boss attack 02");
        swordTrigger.enabled = true;
    }
    
    void BossAttack03()
    {
        attacking = false;
        animator.SetTrigger("bossAttack03");
        attackTimer = 0.0f;
        print("Boss attack 03");
        swordTrigger.enabled = true;
    }
}