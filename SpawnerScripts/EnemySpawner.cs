using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float range = 15f;
    [SerializeField] private float timeBetweenSpawns = 1f;

    private GameObject player;
    private bool playerInRange;

    public Transform enemySpawn;
    public new Rigidbody enemyPrefab;

    private Rigidbody clone;

    void Start()
    {
        enemySpawn = GameObject.Find("Spawner").transform;
        player = GameManager.instance.Player;
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < range)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }

    public IEnumerator SpawnEnemies()
    {
        if (playerInRange && !GameManager.instance.GameOver)
        {
            clone = Instantiate(enemyPrefab, enemySpawn.position, enemySpawn.rotation);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

        yield return null;
        StartCoroutine(SpawnEnemies());
    }
}