using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    public float lifeSpan = 10;
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }
}
