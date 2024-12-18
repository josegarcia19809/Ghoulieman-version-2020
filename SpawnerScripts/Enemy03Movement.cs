using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03Movement : MonoBehaviour
{
    public float moveSpeed;
    private new Rigidbody rigidbody;
    private new Transform transform;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 vel = rigidbody.velocity;
        vel.x = -moveSpeed;
        rigidbody.velocity = vel;
    }
}