using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHBar : MonoBehaviour
{
    [SerializeField] private Image fill;

    [SerializeField] private float fillAmount;
    
    [SerializeField] private float lerpSpeed;

    public GameObject headTrigger;
    private BossHealth health;
    public int currentHealth;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = headTrigger.GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        fill.fillAmount = Mathf.Lerp(fill.fillAmount, fillAmount, lerpSpeed * Time.deltaTime);
        if (currentHealth >= 0)
        {
            currentHealth = health.bossHealth;
            fillAmount= (currentHealth / maxHealth);
        }
    }
}