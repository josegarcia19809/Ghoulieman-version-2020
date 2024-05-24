using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Para el movimiento del Player
    public float maxSpeed = 6.0f;
    public bool facingRight = true;
    public float moveDirection;
    private Rigidbody _rigidbody;
    private Animator _animator;

    //Para el salto simple
    public float jumpSpeed = 600.0f;
    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    // Para el cuchillo
    public float knifeSpeed = 600.0f;
    public Transform knifeSpawn;
    public Rigidbody knifePrefab;
    private Rigidbody clone;
    
    // Para los audios
    private AudioSource _audioSource;
    public AudioClip jumpAudio;

    private void Awake()
    {
        groundCheck = GameObject.Find("GroundCheck").transform;
        knifeSpawn = GameObject.Find("KnifeSpawn").transform;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Para el movimiento
        moveDirection = Input.GetAxis("Horizontal");

        // Para el salto
        if (grounded && Input.GetButtonDown("Jump"))
        {
            _animator.SetTrigger("isJumping");
            _rigidbody.AddForce(new Vector2(0, jumpSpeed));
            _audioSource.PlayOneShot(jumpAudio);
        }
    }

    private void FixedUpdate() // Para actualizaciones en cuerpos rigidos
    {
        _rigidbody.velocity = new Vector2(moveDirection * maxSpeed, _rigidbody.velocity.y);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (moveDirection > 0.0f && !facingRight)
        {
            Flip();
        }
        else if (moveDirection < 0.0f && facingRight)
        {
            Flip();
        }

        _animator.SetFloat("Speed", Mathf.Abs(moveDirection));

        // Para el ataque del Player
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }

    void Attack()
    {
        _animator.SetTrigger("attacking");
    }

    public void CallFireProjectile()
    {
        clone = Instantiate(knifePrefab, knifeSpawn.position,
            knifeSpawn.rotation) as Rigidbody;
        clone.AddForce(knifeSpawn.transform.right * knifeSpeed);
    }
}