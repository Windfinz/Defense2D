using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float playerHealth;

    public void TakeDamage(float dmg)
    {
        playerHealth -= dmg;
        if(playerHealth <= 0)
        {
            //Kill method;
        }
    }

}
