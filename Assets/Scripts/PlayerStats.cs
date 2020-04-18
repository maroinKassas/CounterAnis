using UnityEngine;

public class PlayerStats : CharaterStats
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;

        maxStamina = 100;
        currentStamina = maxStamina;
    }

    public override void Die()
    {
        Debug.Log("You Died");
    }
}
