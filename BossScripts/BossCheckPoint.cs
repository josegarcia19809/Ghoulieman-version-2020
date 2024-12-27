using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheckPoint : MonoBehaviour
{
    public new BoxCollider collider;
    private BossController bossController;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        bossController= GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collider.isTrigger = false;
            bossController.bossAwake = true;
        }
    }
}