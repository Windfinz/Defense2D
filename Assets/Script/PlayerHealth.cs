using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float playerHealth;

    [Header("Health")]
    public Image healthBar;
    public float currentHealth;
    private float targetFill;
    public float fillSpeed;

    private float maxHealth;

    private void Start()
    {
        currentHealth = playerHealth;
        maxHealth = playerHealth;
        UpdateHealthBar();
    }

    private void Update()
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
        }
    }

}
