using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave01Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 50;
    [SerializeField] private int currentHealth = 50;
    [SerializeField] private float timeSinceLastHit = 0.2f;
    [SerializeField] private float dissapearSpeed = 2f;

    private float timer=0f;
    private Animator anim;
    private bool isAlive;
    private new Rigidbody rigidbody;
    private BoxCollider boxCollider;
    private bool dissapearEnemy  = false;
    
    private new AudioSource audio;
    private AudioClip hurtAudio;
    private AudioClip killAudio;
    
    private DropItems dropItem;
    
    public GameObject explosionEffect;

    public bool IsAlive
    {
        get { return isAlive; }
    }
    
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        isAlive = true;
        currentHealth = startingHealth;
        audio = GetComponent<AudioSource>();
        dropItem = GetComponent<DropItems>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
