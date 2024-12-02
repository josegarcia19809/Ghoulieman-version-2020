using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float timer = 0f;
    public float waitTime = 2.0f;

    public GameObject currentCheckpoint;
    private GameObject player;
    private PlayerHealth playerHealth;
    public PlayerHealth playerSlider;
    private CharacterMovement characterMovement;
    public Animator animator;
    private LifeManager lifeManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.Player;
        playerHealth = player.GetComponent<PlayerHealth>();
        playerSlider = player.GetComponent<PlayerHealth>();
        characterMovement = player.GetComponent<CharacterMovement>();
        animator = player.GetComponent<Animator>();
        lifeManager = FindObjectOfType<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RespawnPlayer()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            print("Player Respawn");
            lifeManager.TakeLife();
            player.transform.position = currentCheckpoint.transform.position;
            playerHealth.CurrentHealth = 100;
            timer = 0f;
            playerHealth.HealthSlider.value = playerHealth.CurrentHealth;
            characterMovement.enabled = true;
            animator.Play("Blend Tree");
        }
    }
}