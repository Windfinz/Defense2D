using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float playerMaxHealth;

    [Header("Health")]
    public Image healthBar;
    public float currentHealth;
    private float targetFill;
    public float fillSpeed;

    private float maxHealth;

    GameManager gameManager;

    private void Start()
    {
        currentHealth = playerMaxHealth;
        maxHealth = playerMaxHealth;
        UpdateHealthBar();
        gameManager = GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar() 
    {
        targetFill = currentHealth / maxHealth;
        healthBar.DOFillAmount(targetFill, fillSpeed);
    } 
        

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            //Kill method;
            //gameManager.GameOver();
        }
    }

    public void FireDamage(float dmg, float firedmg, int time)
    {
        currentHealth -= dmg;
        StartCoroutine(DealFireDamageOverTime(firedmg, time));
        if (currentHealth <= 0)
        {
            //Kill method;
        }
    }

    private IEnumerator DealFireDamageOverTime(float firedmg, int time)
    {
        while(time > 0)
        {
            time--;
            currentHealth -= firedmg;
            if (currentHealth <= 0)
            {
                //Kill Method;
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

}
