using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : MonoBehaviour
{
    [SerializeField] private float range = 10f;
    [SerializeField] private float timeBetweenAttacks = 1f;

    private Animator _animator;
    private GameObject player;
    private bool playerInRange;

    public float arrowSpeed = 600f;
    public Transform arrowSpawn;
    public Rigidbody arrowPrefab;

    private Rigidbody clone;

    void Start()
    {
        arrowSpawn = GameObject.Find("ArrowSpawn").transform;
        _animator = GetComponent<Animator>();
        player = GameManager.instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < range)
        {
            playerInRange = true;
            _animator.SetTrigger("isAttacking");
        }
        else
        {
            playerInRange = false;
        }
        
    }

    public void FireArcherProyectile()
    {
        clone = Instantiate(arrowPrefab, arrowSpawn.position,
            arrowSpawn.rotation) as Rigidbody;
        clone.AddForce(-arrowSpawn.transform.right * arrowSpeed);
    }
}